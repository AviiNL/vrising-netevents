using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.StartEditTileModel;

internal class StartEditTileModelEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "StartEditTileModelEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var tile = networkEvent.NetBufferIn.ReadNetworkId();

        var eventArgs = new StartEditTileModelEventArgs(tile);
        
        return eventArgs;
    }
}