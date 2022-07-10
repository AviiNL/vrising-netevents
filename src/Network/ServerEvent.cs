using System;
using NetEvents.EventArgs;

namespace NetEvents.Network;

public static class ServerEvent
{
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

    private static Delegate? GetEventHandler(AbstractEventArgs args)
    {
        switch(args) {
            case ChatMessageEventArgs _:
                return ChatMessage;
            case SetMapMarkerEventArgs _:
                return SetMapMarker;
            case AdminAuthEventArgs _:
                return AdminAuth;
            case DeauthAdminEventArgs _:
                return DeauthAdmin;     
            case UserDownedServerEventArgs _:
                return UserDownedServer;           
            default:
                return null;
        }
    }

    internal static void InvokeEvent(AbstractEventArgs e)
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