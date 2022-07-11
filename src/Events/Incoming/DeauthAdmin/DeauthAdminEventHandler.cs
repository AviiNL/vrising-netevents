using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.DeauthAdmin;

internal class DeauthAdminEventHandler : IIncomingNetworkEventFactory
{
    public string EventName => "DeauthAdminEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var deauthEvent = new DeauthAdminEventArgs();
        deauthEvent.UserEntity = networkEvent.ServerClient!.UserEntity;

        return deauthEvent;
    }
}