using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.EquipItem;

internal class EquipItemEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "EquipItemEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var slotIndex = networkEvent.NetBufferIn.ReadUInt32();

        var eventArgs = new EquipItemEventArgs(
            slotIndex
        );
        
        return eventArgs;
    }
}