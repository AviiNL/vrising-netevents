using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.AdminAuth;

internal class AdminAuthEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "AdminAuthEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var adminAuthEvent = new AdminAuthEventArgs();

        adminAuthEvent.UserEntity = networkEvent.ServerClient!.UserEntity;

        return adminAuthEvent;
    }
}