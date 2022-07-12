using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.BecomeObserver;

internal class BecomeObserverEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "BecomeObserverEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var mode = (int)networkEvent.NetBufferIn.ReadUInt32();

        var becomeObserver = new BecomeObserverEventArgs(mode);

        return becomeObserver;
    }
}