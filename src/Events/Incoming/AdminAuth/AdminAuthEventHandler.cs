using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.AdminAuth;

internal class AdminAuthEventHandler : IIncomingNetworkEventHandler
{
    public string EventName => "AdminAuthEvent";
    public bool Enabled => true;

    public void Handle(IncomingNetworkEvent networkEvent, out bool cancelled)
    {
        var adminAuthEvent = new AdminAuthEventArgs();
        adminAuthEvent.UserEntity = networkEvent.ServerClient!.UserEntity;

        ServerEvent.InvokeEvent(adminAuthEvent);
        cancelled = adminAuthEvent.Cancelled;
    }
}