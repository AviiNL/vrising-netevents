using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.SetMapMarker;

internal class SetMapMarkerEventHandler : IIncomingNetworkEventHandler
{
    public string EventName => "SetMapMarkerEvent";
    public bool Enabled => true;

    public void Handle(IncomingNetworkEvent networkEvent, out bool cancelled)
    {
        var x = networkEvent.NetBufferIn.ReadFloat();
        var y = networkEvent.NetBufferIn.ReadFloat();

        var mapMarker = new SetMapMarkerEventArgs(new Unity.Mathematics.float2(x, y));

        mapMarker.UserEntity = networkEvent.ServerClient!.UserEntity;

        ServerEvent.InvokeEvent(mapMarker);
        cancelled = mapMarker.Cancelled;
    }
}