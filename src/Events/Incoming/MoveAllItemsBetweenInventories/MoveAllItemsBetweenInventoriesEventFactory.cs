using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.MoveAllItemsBetweenInventories;

internal class MoveAllItemsBetweenInventoriesEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "MoveAllItemsBetweenInventoriesEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var fromInventory = networkEvent.NetBufferIn.ReadNetworkId();
        var toInventory = networkEvent.NetBufferIn.ReadNetworkId();

        var eventArgs = new MoveAllItemsBetweenInventoriesEventArgs(
            fromInventory,
            toInventory
        );

        eventArgs.UserEntity = networkEvent.UserEntity;

        return eventArgs;
    }
}