using NetEvents.Network.Models;

namespace NetEvents.Network.Interfaces;

internal interface IOutgoingNetworkEventHandler : INetworkEventHandler
{
    void Handle(OutgoingNetworkEvent networkEvent, out bool cancelled);
}