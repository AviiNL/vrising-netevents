using NetEvents.Network.Models;

namespace NetEvents.Network.Interfaces;

internal interface IIncomingNetworkEventHandler : INetworkEventHandler
{
    void Handle(IncomingNetworkEvent networkEvent, out bool cancelled);
}