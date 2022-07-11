using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.DeauthAdmin;

internal class DeauthAdminEventHandler : IIncomingNetworkEventHandler
{
    public string EventName => EventNames.DeauthAdminEvent;
    public bool Enabled => true;

    public void Handle(IncomingNetworkEvent networkEvent, out bool cancelled)
    {
        var deauthEvent = DeauthAdminEventArgs.From();
        deauthEvent.UserEntity = networkEvent.ServerClient!.UserEntity;

        ServerEvent.InvokeEvent(deauthEvent);
        cancelled = deauthEvent.Cancelled;
    }
}