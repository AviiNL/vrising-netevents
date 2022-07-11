using System;
using NetEvents.Events;
using NetEvents.Events.Incoming.ActivateVBloodAbility;
using NetEvents.Events.Incoming.AdminAuth;
using NetEvents.Events.Incoming.BuildTileModel;
using NetEvents.Events.Incoming.ChatMessage;
using NetEvents.Events.Incoming.DeauthAdmin;
using NetEvents.Events.Incoming.SetMapMarker;
using NetEvents.Events.Outgoing.UserDownedServer;

namespace NetEvents.Network;

public static class ServerEvent
{
    static ServerEvent()
    {
        NetworkEventManager.RegisterEvents(typeof(ServerEvent));
    }

    public delegate void ChatMessageEventHandler(ChatMessageEventArgs e);
    public static event ChatMessageEventHandler? ChatMessage;

    public delegate void SetMapMarkerEventHandler(SetMapMarkerEventArgs e);
    public static event SetMapMarkerEventHandler? SetMapMarker;

    public delegate void AdminAuthEventHandler(AdminAuthEventArgs e);
    public static event AdminAuthEventHandler? AdminAuth;

    public delegate void DeauthAdminEventHandler(DeauthAdminEventArgs e);
    public static event DeauthAdminEventHandler? DeauthAdmin;

    public delegate void UserDownedServerEventHandler(UserDownedServerEventArgs e);
    public static event UserDownedServerEventHandler? UserDownedServer;

    public delegate void ActivateVBloodAbilityEventHandler(ActivateVBloodAbilityEventArgs e);
    public static event ActivateVBloodAbilityEventHandler? ActivateVBloodAbility;

    public delegate void BuildTileModelEventHandler(BuildTileModelEventArgs e);
    public static event BuildTileModelEventHandler? BuildTileModel;

    private static Delegate? GetEventHandler<T>() where T : AbstractEventArgs
    {
        return typeof(T).Name switch
        {
            nameof(ChatMessageEventArgs) => ChatMessage,
            nameof(SetMapMarkerEventArgs) => SetMapMarker,
            nameof(AdminAuthEventArgs) => AdminAuth,
            nameof(DeauthAdminEventArgs) => DeauthAdmin,
            nameof(UserDownedServerEventArgs) => UserDownedServer,
            nameof(ActivateVBloodAbilityEventArgs) => ActivateVBloodAbility,
            nameof(BuildTileModelEventArgs) => BuildTileModel,
            _ => null
        };
    }

    internal static void InvokeEvent<T>(T e) where T : AbstractEventArgs
    {
        // Find which delegate takes e as parameter
        var eventHandler = GetEventHandler<T>();
        if (eventHandler == null) return;

        // Invoke the event handler
        foreach (var invoker in eventHandler.GetInvocationList())
        {
            invoker.DynamicInvoke(e);
            if (e.Cancelled) return;
        }
    }


}