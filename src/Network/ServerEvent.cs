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
    /// This event is fired when a player kills an NPC or a resource.
    /// </summary>
    public static event GenericEventDelegate<UserKillServerEventArgs>? UserKillServer;


    private static Delegate? GetEventHandler<T>(T e) where T : AbstractEventArgs
    {
        return e.GetType().Name switch
        {
            nameof(ChatMessageEventArgs) => ChatMessage,
            nameof(SetMapMarkerEventArgs) => SetMapMarker,
            nameof(AdminAuthEventArgs) => AdminAuth,
            nameof(DeauthAdminEventArgs) => DeauthAdmin,
            nameof(UserDownedServerEventArgs) => UserDownedServer,
            nameof(ActivateVBloodAbilityEventArgs) => ActivateVBloodAbility,
            nameof(BuildTileModelEventArgs) => BuildTileModel,
            nameof(CreateClan_RequestEventArgs) => CreateClan_Request,
            nameof(UserKillServerEventArgs) => UserKillServer,
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