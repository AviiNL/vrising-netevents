using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using ProjectM.Network;

namespace NetEvents.Events.Incoming.StopInteractingWithObject;

internal class StopInteractingWithObjectEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "StopInteractingWithObjectEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var target = networkEvent.NetBufferIn.ReadNetworkId();

        var eventArgs = new StopInteractingWithObjectEventArgs(
            target
        );
        
        return eventArgs;
    }
}
