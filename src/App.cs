using ProjectM.Network;
using NetEvents.Utils;
using UnityEngine;
using NetEvents.Events.Incoming.AdminAuth;
using NetEvents.Events.Incoming.ChatMessage;
using NetEvents.Events.Incoming.DeauthAdmin;
using NetEvents.Network;
using ProjectM;
using NetEvents.Events.Outgoing.UserDownedServer;

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

        Plugin.Logger?.LogMessage($"ChatMessageEventArgs: [{user.CharacterName}] {e.MessageType} {e.MessageText}");
    }
}
