using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Outgoing.UserKill;

internal class UserKillServerEventHandler : IOutgoingNetworkEventHandler
{
    public string EventName => EventNames.UserKillServerEvent;
    public bool Enabled => true;
    public void Handle(OutgoingNetworkEvent networkEvent, out bool cancelled)
    {
        var userKillServer = UserKillServerEventArgs.From(networkEvent.EntityManager, networkEvent.Entity);
        ServerEvent.InvokeEvent(userKillServer);
        cancelled = userKillServer.Cancelled;
    }
}