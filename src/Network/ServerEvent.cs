using System;
using NetEvents.Events;

namespace NetEvents.Network;

public static class ServerEvent
{
    static ServerEvent()
    {
        NetworkEventManager.RegisterEvents(typeof(ServerEvent));
    }

    public delegate void GenericEventDelegate<T>(T args) where T : AbstractEventArgs;

    /// <summary>
    /// This event is fired when a player sends a chat message.
    /// </summary>
    public static event GenericEventDelegate<ChatMessageEventArgs>? ChatMessage;

    /// <summary>
    /// This event is fired when a player logs in as an admin.
    /// </summary>
    public static event GenericEventDelegate<AdminAuthEventArgs>? AdminAuth;

    /// <summary>
    /// This event is fired when a player logs out as an admin.
    /// </summary>
    public static event GenericEventDelegate<DeauthAdminEventArgs>? DeauthAdmin;

    /// <summary>
    /// This event is fired when a player sets a waypoint on their map.
    /// </summary>
    public static event GenericEventDelegate<SetMapMarkerEventArgs>? SetMapMarker;

    /// <summary>
    /// This event is fired when a player has been downed by another player in PvP.
    public static event GenericEventDelegate<UserDownedServerEventArgs>? UserDownedServer;

    /// <summary>
    /// This event is fired when a player adds an ability to their hotbar.
    /// </summary>
    public static event GenericEventDelegate<ActivateVBloodAbilityEventArgs>? ActivateVBloodAbility;

    /// <summary>
    /// This event is fired when a player creates a clan.
    /// </summary>
    public static event GenericEventDelegate<CreateClan_RequestEventArgs>? CreateClan_Request;

    /// <summary>
    /// This event is fired when a player builds a tile model.
    /// </summary>
    public static event GenericEventDelegate<BuildTileModelEventArgs>? BuildTileModel;

    /// <summary>
    /// This event is fired when a player kills something, this includes resource nodes and foliage.
    /// </summary>
    public static event GenericEventDelegate<UserKillServerEventArgs>? UserKillServer;

    /// <summary>
    /// This event is fired when an admin changes their observer state.
    /// </summary>
    public static event GenericEventDelegate<BecomeObserverEventArgs>? BecomeObserver;

    /// <summary>
    /// This event is fired when a player drops an item from their inventory by dragging it out of the window.
    /// </summary>
    public static event GenericEventDelegate<DropInventoryItemEventArgs>? DropInventoryItem;

    /// <summary>
    /// This event is fired when a player drops an item by pressing spacebar on the item in their inventory.
    /// </summary>
    public static event GenericEventDelegate<DropItemAtSlotEventArgs>? DropItemAtSlot;

    /// <summary>
    /// This event is fired when a player dies (afaik only when a player uses "Unstuck" from the menu)
    /// </summary>
    public static event GenericEventDelegate<KillEventArgs>? KillEvent;

    /// <summary>
    /// This event is fired when a player moves all items from one inventory to another.
    /// </summary>
    public static event GenericEventDelegate<MoveAllItemsBetweenInventoriesEventArgs>? MoveAllItemsBetweenInventories;

    /// <summary>
    /// This event is fired when a player moves a single stack of items from one inventory to another.
    /// </summary>
    public static event GenericEventDelegate<MoveItemBetweenInventoriesEventArgs>? MoveItemBetweenInventories;

    /// <summary>
    /// This event is fired when a player moves an object via the build menu.
    /// </summary>
    public static event GenericEventDelegate<MoveTileModelEventArgs>? MoveTileModel;

    /// <summary>
    /// This event is fired when someone attempts to teleports around the map.
    /// </summary>
    public static event GenericEventDelegate<PlayerTeleportDebugEventArgs>? PlayerTeleportDebug;

    /// <summary>
    /// This event is fired when a player requests to sort all items in an inventory.
    /// </summary>
    public static event GenericEventDelegate<SortAllItemsEventArgs>? SortAllItems;

    /// <summary>
    /// This event is fired when a player selects an object in build mode.
    /// </summary>
    public static event GenericEventDelegate<StartEditTileModelEventArgs>? StartEditTileModel;

    /// <summary>
    /// This event is fired when a player stops interacting with an object, eg a chest or workstation.
    /// </summary>
    public static event GenericEventDelegate<StopInteractingWithObjectEventArgs>? StopInteractingWithObject;

    /// <summary>
    /// This event is fired when a client requests authentication with Vivox VOIP Services.
    /// </summary>
    public static event GenericEventDelegate<VivoxClientEventArgs>? VivoxClient;

    /// <summary>
    /// This event is fired when a player interacts with a workstation.
    /// </summary>
    public static event GenericEventDelegate<ShareRefinementEventArgs>? ShareRefinement;

    /// <summary>
    /// This event is fired when a player equips an item.
    /// </summary>
    public static event GenericEventDelegate<EquipItemEventArgs>? EquipItem;

    /// <summary>
    /// This event is fired when a player unequips an item.
    /// </summary>
    public static event GenericEventDelegate<UnequipItemEventArgs>? UnequipItem;

    /// <summary>
    /// This event is fired when a player uses default action (left ctrl) eg, exit shapeshift.
    /// </summary>
    public static event GenericEventDelegate<UseDefaultActionEventArgs>? UseDefaultAction;

    /// <summary>
    /// This event is fired when a player enters a shapeshift form.
    /// </summary>
    public static event GenericEventDelegate<EnterShapeshiftEventArgs>? EnterShapeshift;

    /// <summary>
    /// This event is fired when a player gives up after being downed.
    /// For some reason this event triggers multiple times if the player holds X for longer.
    /// </summary>
    public static event GenericEventDelegate<GiveUpReviveEventArgs>? GiveUpRevive;

    /// <summary>
    /// This event is fired when a player requests to respawn.
    /// </summary>
    public static event GenericEventDelegate<CharacterRespawnEventArgs>? CharacterRespawn;

    private static Delegate? GetEventHandler<T>(T e) where T : AbstractEventArgs
    {
        return e.GetType().Name switch
        {
            nameof(KillEventArgs) => KillEvent,
            nameof(AdminAuthEventArgs) => AdminAuth,
            nameof(EquipItemEventArgs) => EquipItem,
            nameof(ChatMessageEventArgs) => ChatMessage,
            nameof(DeauthAdminEventArgs) => DeauthAdmin,
            nameof(UnequipItemEventArgs) => UnequipItem,
            nameof(VivoxClientEventArgs) => VivoxClient,
            nameof(GiveUpReviveEventArgs) => GiveUpRevive,
            nameof(SetMapMarkerEventArgs) => SetMapMarker,
            nameof(SortAllItemsEventArgs) => SortAllItems,
            nameof(MoveTileModelEventArgs) => MoveTileModel,
            nameof(BecomeObserverEventArgs) => BecomeObserver,
            nameof(BuildTileModelEventArgs) => BuildTileModel,
            nameof(DropItemAtSlotEventArgs) => DropItemAtSlot,
            nameof(UserKillServerEventArgs) => UserKillServer,
            nameof(EnterShapeshiftEventArgs) => EnterShapeshift,
            nameof(ShareRefinementEventArgs) => ShareRefinement,
            nameof(CharacterRespawnEventArgs) => CharacterRespawn,
            nameof(UseDefaultActionEventArgs) => UseDefaultAction,
            nameof(UserDownedServerEventArgs) => UserDownedServer,
            nameof(DropInventoryItemEventArgs) => DropInventoryItem,
            nameof(CreateClan_RequestEventArgs) => CreateClan_Request,
            nameof(StartEditTileModelEventArgs) => StartEditTileModel,
            nameof(PlayerTeleportDebugEventArgs) => PlayerTeleportDebug,
            nameof(ActivateVBloodAbilityEventArgs) => ActivateVBloodAbility,
            nameof(StopInteractingWithObjectEventArgs) => StopInteractingWithObject,
            nameof(MoveItemBetweenInventoriesEventArgs) => MoveItemBetweenInventories,
            nameof(MoveAllItemsBetweenInventoriesEventArgs) => MoveAllItemsBetweenInventories,
            _ => null
        };
    }

    internal static void InvokeEvent<T>(T e) where T : AbstractEventArgs
    {
        // Find which delegate takes e as parameter
        var eventHandler = GetEventHandler(e);
        if (eventHandler == null) return;

        // Invoke the event handler
        foreach (var invoker in eventHandler.GetInvocationList())
        {
            invoker.DynamicInvoke(e);
            if (e.Cancelled) return;
        }
    }
}