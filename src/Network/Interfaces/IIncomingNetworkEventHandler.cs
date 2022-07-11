using NetEvents.Network.Models;

namespace NetEvents.Network.Interfaces;

public interface IIncomingNetworkEventHandler : INetworkEventHandler
{
    void Handle(IncomingNetworkEvent networkEvent, out bool cancelled);
}