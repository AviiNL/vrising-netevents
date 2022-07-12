using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using ProjectM.Network;

namespace NetEvents.Events.Incoming.MoveItemBetweenInventories;

internal class MoveItemBetweenInventoriesEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "MoveItemBetweenInventoriesEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var fromInventory = networkEvent.NetBufferIn.ReadNetworkId();
        var fromSlot = networkEvent.NetBufferIn.ReadUInt32();

        // to inventory
        var toInventory = networkEvent.NetBufferIn.ReadNetworkId();
        var toSlot = networkEvent.NetBufferIn.ReadUInt32();

        var transferMethod = (ItemTransferMethod)networkEvent.NetBufferIn.ReadByte();

        var eventArgs = new MoveItemBetweenInventoriesEventArgs(
            fromInventory,
            fromSlot,
            toInventory,
            toSlot,
            transferMethod
        );
        
        return eventArgs;
    }
}