using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using ProjectM.Network;

namespace NetEvents.Events.Incoming.ShareRefinement;

internal class ShareRefinementEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "ShareRefinementEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var station = networkEvent.NetBufferIn.ReadNetworkId();

        var eventArgs = new ShareRefinementEventArgs(
            station
        );
        
        return eventArgs;
    }
}