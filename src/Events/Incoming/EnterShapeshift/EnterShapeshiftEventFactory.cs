using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.EnterShapeshift;

internal class EnterShapeshiftEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "EnterShapeshiftEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var shapeshift = networkEvent.NetBufferIn.ReadPrefabGUID();
        var exitOnSameForm = networkEvent.NetBufferIn.ReadBoolean();

        var eventArgs = new EnterShapeshiftEventArgs(
            shapeshift,
            exitOnSameForm
        );
        
        return eventArgs;
    }
}