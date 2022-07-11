using NetEvents.Events;
using NetEvents.Network.Models;

namespace NetEvents.Network.Interfaces;

public interface IOutgoingNetworkEventFactory : INetworkEventFactory
{
    AbstractEventArgs Build(OutgoingNetworkEvent networkFactory);
}