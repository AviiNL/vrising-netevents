using NetEvents.Events;
using NetEvents.Network.Models;

namespace NetEvents.Network.Interfaces;

public interface IIncomingNetworkEventFactory : INetworkEventFactory
{
    AbstractEventArgs Build(IncomingNetworkEvent networkFactory);
}