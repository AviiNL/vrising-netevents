using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Outgoing.UserDowned
{
    internal class UserDownedServerEventHandler : IOutgoingNetworkEventHandler
    {
        public string EventName => EventNames.UserDownedServerEvent;
        public bool Enabled => true;
        public void Handle(OutgoingNetworkEvent networkEvent, out bool cancelled)
        {
            var userDownedServer = UserDownedServerEventArgs.From(networkEvent.EntityManager, networkEvent.Entity);
            ServerEvent.InvokeEvent(userDownedServer);
            cancelled = userDownedServer.Cancelled;
        }
    }
}
