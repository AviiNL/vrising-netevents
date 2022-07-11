using NetEvents.Network.Models;

namespace NetEvents.Network.Interfaces;

public interface IOutgoingNetworkEventHandler : INetworkEventHandler
{
    void Handle(OutgoingNetworkEvent networkEvent, out bool cancelled);
}