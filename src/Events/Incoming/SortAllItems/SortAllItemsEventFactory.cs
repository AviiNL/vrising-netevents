using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.SortAllItems;

internal class SortAllItemsEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "SortAllItemsEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var inventory = networkEvent.NetBufferIn.ReadNetworkId();

        var eventArgs = new SortAllItemsEventArgs(inventory);
        
        return eventArgs;
    }
}