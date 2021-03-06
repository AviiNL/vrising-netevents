using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.DeauthAdmin;

internal class DeauthAdminEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "DeauthAdminEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var deauthEvent = new DeauthAdminEventArgs();

        return deauthEvent;
    }
}