using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BepInEx.IL2CPP.Hook;
using ProjectM;
using ProjectM.Network;
using NetEvents.Utils;
using Stunlock.Network;

using static NetworkEvents_Serialize;
using static ProjectM.Network.ClanEvents_Client;
using static ProjectM.Network.ClanEvents_Server;
using static ProjectM.Network.InteractEvents_Client;
using static ProjectM.TeleportEvents_ToServer;
using NetEvents.Network.Models;
using Unity.Entities;

namespace NetEvents.Network;

// Create Clan               = 2886047490 
// Leave Clan/Clan Disbanded = 2215823930
// Clan Changed              = 2112226552

/// Contains the serialization hooks for custom packets.
internal static class SerializationHooks
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public unsafe delegate void SerializeEvent(IntPtr entityManager, UInt64 networkEventType, UInt64 netBufferOut, IntPtr entity);
    public static SerializeEvent? SerializeOriginal;
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public unsafe delegate void DeserializeEvent(IntPtr commandBuffer, IntPtr netBuffer, DeserializeNetworkEventParams eventParams);
    public static DeserializeEvent? DeserializeOriginal;

    // This dictonary is never used, however it's useful to be able to CTRL+Click the classes to see what fields needs to be propogated to the events.
    private static Dictionary<int, Type> _packetTypes = new()
    {
        { -1593849993, typeof(RestorStationEvent) },
        { -810031139, typeof(RevealedMapEvent) },
        { 1919105157, typeof(SendOnMissionEvent) },
        { -433375529, typeof(SerializePersistenceFailedFeedbackEvent) },
        { -1094803353, typeof(ServantCoffinActionEvent) },
        { 520077498, typeof(ServantMissionFinishedEvent) },
        { -1997647067, typeof(ServantMissionStartedEvent) },
        { -56791601, typeof(ServerIsRestartingServerEvent) },
        { -2116544812, typeof(ServerSalvageEventSucceeded) },
        { -1404674526, typeof(SetDebugSettingEvent) },
        { -132110655, typeof(SetMapMarkerEvent) },
        { 1531561759, typeof(ResetServerLogsEvent) },
        { -557401683, typeof(ResetScheduleNotificationEvent) },
        { 1866754375, typeof(MoveAllItemsBetweenInventoriesEvent) },
        { 244508992, typeof(MoveItemBetweenInventoriesEvent) },
        { 1928228277, typeof(MoveTileModelEvent) },
        { -1903352354, typeof(NewSiegeWeapon) },
        { 1098234825, typeof(PurchaseProgressionUnlock) },
        { 1929940379, typeof(PvPToggleEvent) },
        { 1158104209, typeof(RegisterCharacterNameEvent) },
        { -1713906420, typeof(RemovePvPProtectionEvent) },
        { 414014614, typeof(RenameInteractable) },
        { 862289006, typeof(RepairEquippedItemEvent) },
        { -1778152914, typeof(RepairItemEvent) },
        { -84973825, typeof(RepairTileModelEvent) },
        { 1737733572, typeof(ResetBuffAgeServerEvent) },
        { -1990731433, typeof(SetTimeOfDayEvent) },
        { -1330112954, typeof(SetUserAdminLevelAdminEvent) },
        { -2126367915, typeof(TryInsertBloodEvent) },
        { 161700889, typeof(UnequipItemEvent) },
        { -80575929, typeof(UnequipServantItemEvent) },
        { -793850092, typeof(UnlockAllVBloodAbilities) },
        { -1559809502, typeof(UnlockAllVBloodPassives) },
        { -1514426036, typeof(UnlockAllVBloodShapeshifts) },
        { -789147806, typeof(UnlockProgressionServerEvent) },
        { -1262836687, typeof(UnlockResearchEvent) },
        { -1615578112, typeof(UpgradePylonEvent) },
        { 709103918, typeof(UseDefaultActionEvent) },
        { -1521268900, typeof(UseEmoteEvent) },
        { -1522376918, typeof(UseItemEvent) },
        { -1952253415, typeof(UserDownedServerEvent) },
        { -775620345, typeof(UserKillServerEvent) },
        { -933064673, typeof(VivoxClientEvent) },
        { 1806113822, typeof(VivoxClientStateEvent) },
        { -741486154, typeof(VivoxServerChannelEvent) },
        { 550223043, typeof(ToggleUserPermissionsEvent) },
        { 561197515, typeof(ToggleSalvageEvent) },
        { -1145461241, typeof(ToggleRefiningEvent) },
        { -82029052, typeof(TeleportToWaypointEvent) },
        { -2131391704, typeof(ShareRefinementEvent) },
        { -2035698677, typeof(ShareUnitspawnerRecipesEvent) },
        { -954936318, typeof(ShareVBloodEvent) },
        { -1794409837, typeof(SmartMergeItemsBetweenInventoriesEvent) },
        { -537043085, typeof(SortAllItemsEvent) },
        { 184382987, typeof(SplitItemEvent) },
        { -215712725, typeof(StartCharacterCraftItemEvent) },
        { -124733032, typeof(MapZoneDiscoveredEvent) },
        { -382113386, typeof(StartCraftItemEvent) },
        { 232373286, typeof(StartTrackVBloodUnitEvent) },
        { 2133780581, typeof(StopCharacterCraftItemEvent) },
        { 1005710797, typeof(StopCraftItemEvent) },
        { 1426509984, typeof(StopInteractingWithObjectEvent) },
        { -625686139, typeof(StopTrackVBloodUnitEvent) },
        { 858012035, typeof(TeleportToNetherEvent) },
        { -1928510276, typeof(StartEditTileModelEvent) },
        { 1164388223, typeof(LevelUpServerEvent) },
        { 415000408, typeof(VivoxServerRejectEvent) },
        { -1321774808, typeof(LeaveClanResultResponse) },
        { 2065537616, typeof(ChangeRole_Request) },
        { 1404061179, typeof(ChangeServantNameEvent) },
        { 623644935, typeof(CharacterHasRespawnedEvent) },
        { -547595642, typeof(CharacterRespawnEvent) },
        { 1684188553, typeof(ChatMessageEvent) },
        { -1996620953, typeof(ChatMessageServerEvent) },
        { -514702814, typeof(ClaimAchievementEvent) },
        { -712700624, typeof(ClaimedAchievementsEvent) },
        { 1262216071, typeof(ClaimPylonEvent) },
        { 141291906, typeof(ClaimVBloodEvent) },
        { -237320060, typeof(ClanInvitationResponse) },
        { 1024721104, typeof(ClanInvitationResult) },
        { -402826727, typeof(VivoxServerLoginEvent) },
        { -1659093300, typeof(ClanModifiedEvent) },
        { -836466410, typeof(ClientActionResponseEvent) },
        { 1671084942, typeof(ClientSalvageEvent) },
        { -1046626917, typeof(CastleWallBreachedEvent) },
        { 341670078, typeof(AbortMissionEvent) },
        { 402428485, typeof(AcceptClanInviteResultResponse) },
        { -2103827848, typeof(AchievementClaimedServerEvent) },
        { 961738838, typeof(ActivateVBloodAbilityEvent) },
        { -227264250, typeof(AdminAuthEvent) },
        { -1529872085, typeof(BanEvent) },
        { 1226547410, typeof(BannedEvent_Reponse) },
        { 336167205, typeof(BannedEvent_Request) },
        { -1020557761, typeof(BecomeObserverEvent) },
        { 825449274, typeof(BuildTileModelEvent) },
        { -1678684907, typeof(BuildWallpaperEvent) },
        { -329748534, typeof(CancelEditTileModelEvent) },
        { 1104262315, typeof(CastleAttackedEvent) },
        { 1647897359, typeof(CompleteAllAchievementsEvent) },
        { 138849668, typeof(ClanInviteResponse) },
        { -1208165990, typeof(EnterShapeshiftEvent) },
        { 9548331, typeof(EquipItemEvent) },
        { -471759703, typeof(EquipmentToEquipmentTransferEvent) },
        { 48834372, typeof(EquipServantItemEvent) },
        { -352379332, typeof(EquipServantItemFromInventoryEvent) },
        { 320517370, typeof(GiveUpReviveEvent) },
        { 1464084880, typeof(InitialUnlockedProgressionEvent) },
        { -1018357742, typeof(InteractWithPrisonerEvent) },
        { 1402714220, typeof(InvitePlayerToClan) },
        { -1718203525, typeof(JumpToNextBloodMoonEvent) },
        { 1860866954, typeof(Kick_Request) },
        { 980637812, typeof(KickEvent) },
        { -76856582, typeof(KillEvent) },
        { -2079143366, typeof(LeaveClan) },
        { 2112226552, typeof(EditClan) },
        { -1012179922, typeof(DropItemAtSlotEvent) },
        { -1035165200, typeof(EquipItemFromInventoryEvent) },
        { 1232157931, typeof(DropEquippedItemEvent) },
        { 527272789, typeof(CreateCharacterEvent) },
        { -614746680, typeof(CreateCharacterResponseEvent) },
        { -1408919806, typeof(CreateClan_Request) },
        { -1417703296, typeof(DropInventoryItemEvent) },
        { -1335026116, typeof(CustomizeCharacterEvent) },
        { 1613211627, typeof(DeauthAdminEvent) },
        { 1959082597, typeof(DebugTeleportToEntityEvent) },
        { -775377968, typeof(CreateClan_Response) },
        { 1026574565, typeof(DecayEvent) },
        { -531442865, typeof(DeleteMapMarkerEvent) },
        { -1854725185, typeof(DestroyPylonEvent) },
        { 1040656247, typeof(DiscoveredMapZonesEvent) },
        { 276892544, typeof(DiscoverResearchEvent) },
        { 285035802, typeof(DismantleTileModelEvent) },
        { -1022103040, typeof(DebugTeleportToNetherEvent) },
    };

    private static FastNativeDetour? _serializeDetour;
    private static FastNativeDetour? _deserializeDetour;

    public static void Initialize()
    {
        unsafe
        {
            _serializeDetour = NativeHookUtil.Detour(typeof(NetworkEvents_Serialize), "SerializeEvent", SerializeHook, out SerializeOriginal);
            _deserializeDetour = NativeHookUtil.Detour(typeof(NetworkEvents_Serialize), "DeserializeEvent", DeserializeHook, out DeserializeOriginal);
        }
    }

    public static void Uninitialize()
    {
        _serializeDetour?.Dispose();
        _deserializeDetour?.Dispose();
    }

    // Outgoing events (Server->Client)
    public static unsafe void SerializeHook(IntPtr entityManager, UInt64 networkEventType, UInt64 netBufferOut, IntPtr entity)
    {
        var eventType = *(NetworkEventType*)&networkEventType;

        var eventId = eventType.EventId;

        var em = *(EntityManager*)&entityManager;
        var realEntity = *(Entity*)&entity;

        var networkEvent = new OutgoingNetworkEvent(eventType, eventId, em, realEntity);

        NetworkEventManager.HandleEvent(networkEvent, out var cancelled);

        if (cancelled)
        {
            return;
        }

        SerializeOriginal!(entityManager, networkEventType, netBufferOut, entity);
    }

    // Incoming Events (Client->Server)
    public static unsafe void DeserializeHook(IntPtr commandBuffer, IntPtr netBuffer, DeserializeNetworkEventParams eventParams)
    {
        var netBufferIn = new NetBufferIn(new IntPtr((long)(netBuffer - 0x10)));
        var eventId = netBufferIn.ReadInt32();

        var networkEvent = new IncomingNetworkEvent(netBufferIn, eventId, eventParams);

        NetworkEventManager.HandleEvent(networkEvent, out var cancelled);
        
        if (cancelled)
        {
            return;
        }

        netBufferIn.m_readPosition = 72;
        DeserializeOriginal!(commandBuffer, netBuffer, eventParams);
    }

}