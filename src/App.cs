using ProjectM.Network;
using NetEvents.Utils;
using UnityEngine;
using NetEvents.Network;
using ProjectM;
using NetEvents.Events;

namespace NetEvents;

public class App : MonoBehaviour
{
    public void Start()
    {
        Plugin.Logger?.LogDebug("App Start");
        ServerEvent.ChatMessage += this.OnChatMessage;
        ServerEvent.AdminAuth += this.OnAdminAuth;
        ServerEvent.DeauthAdmin += this.OnAdminDeAuth;
        ServerEvent.UserDownedServer += this.OnUserDownedServer;
        ServerEvent.BuildTileModel += this.OnBuildTileModel;
        ServerEvent.ActivateVBloodAbility += this.OnActivateVBloodAbility;
        ServerEvent.CreateClan_Request += this.OnCreateClan_Request;
    }

    public void OnCreateClan_Request(CreateClan_RequestEventArgs e)
    {
        Plugin.Logger?.LogDebug("CreateClan_Request");
        Plugin.Logger?.LogDebug($"ClanName: {e.ClanName}");
        Plugin.Logger?.LogDebug($"ClanMotto: {e.ClanMotto}");
    }

    public void OnActivateVBloodAbility(ActivateVBloodAbilityEventArgs e)
    {
        Plugin.Logger?.LogDebug("ActivateVBloodAbility");
    }

    public void OnBuildTileModel(BuildTileModelEventArgs e)
    {
        e.Cancelled = true; // This should prevent building all together.
        
        Plugin.Logger?.LogDebug($"OnBuildTileModel: {e.PrefabGuid} {e.SpawnPosition} {e.SpawnTileRotation} {e.TransformedEntity}");
    }

    public void OnUserDownedServer(UserDownedServerEventArgs e)
    {
        var serverBootstrap = WorldUtils.GetWorld().GetExistingSystem<ServerBootstrapSystem>();
        var em = WorldUtils.GetWorld().EntityManager;

        var killed = em.GetComponentData<User>(e.Target.UserEntity._Entity);
        var killer = em.GetComponentData<User>(e.Source.UserEntity._Entity);

        Plugin.Logger?.LogDebug($"{killer.CharacterName} killed {killed.CharacterName}");
    }
    
    public void OnAdminDeAuth(DeauthAdminEventArgs e) {
        var user = WorldUtils.GetWorld().EntityManager.GetComponentData<User>(e.UserEntity);

        Plugin.Logger?.LogMessage($"{user.CharacterName} has logged out from admin");
    }

    public void OnAdminAuth(AdminAuthEventArgs e) {
        var user = WorldUtils.GetWorld().EntityManager.GetComponentData<User>(e.UserEntity);

        Plugin.Logger?.LogMessage($"{user.CharacterName} has logged in as admin");
    }

    public void OnChatMessage(ChatMessageEventArgs e)
    {
        var user = WorldUtils.GetWorld().EntityManager.GetComponentData<User>(e.UserEntity);

        if (e.MessageType == ChatMessageType.Whisper) {
            Plugin.Logger?.LogDebug($"Receiver network id: {e.ReceiverEntity}");
        }

        Plugin.Logger?.LogMessage($"ChatMessageEventArgs: [{user.CharacterName}] {e.MessageType} {e.MessageText}");
    }
}
