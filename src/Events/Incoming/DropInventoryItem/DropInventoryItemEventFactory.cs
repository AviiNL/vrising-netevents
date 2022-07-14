using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.BecomeObserver;

internal class DropInventoryItemEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "DropInventoryItemEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var inventory = networkEvent.NetBufferIn.ReadNetworkId();
        var slot = networkEvent.NetBufferIn.ReadUInt32();

        var dropInventoryItem = new DropInventoryItemEventArgs(inventory, slot);

        return dropInventoryItem;
    }
}