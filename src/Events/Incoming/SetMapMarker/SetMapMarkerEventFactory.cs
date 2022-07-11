using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.SetMapMarker;

internal class SetMapMarkerEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "SetMapMarkerEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var x = networkEvent.NetBufferIn.ReadFloat();
        var y = networkEvent.NetBufferIn.ReadFloat();

        var mapMarker = new SetMapMarkerEventArgs(new Unity.Mathematics.float2(x, y));

        mapMarker.UserEntity = networkEvent.ServerClient!.UserEntity;

        return mapMarker;
    }
}