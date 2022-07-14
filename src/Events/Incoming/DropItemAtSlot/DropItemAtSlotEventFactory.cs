using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.BecomeObserver;

internal class DropItemAtSlotEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "DropItemAtSlotEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var slotIndex = networkEvent.NetBufferIn.ReadInt32();

        var dropItemAtSlot = new DropItemAtSlotEventArgs(slotIndex);

        return dropItemAtSlot;
    }
}