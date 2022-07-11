using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.SetMapMarker;

internal class SetMapMarkerEventHandler : IIncomingNetworkEventHandler
{
    public string EventName => EventNames.SetMapMarkerEvent;
    public bool Enabled => true;

    public void Handle(IncomingNetworkEvent networkEvent, out bool cancelled)
    {
        var mapMarker = SetMapMarkerEventArgs.From(networkEvent.NetBufferIn);

        mapMarker.UserEntity = networkEvent.ServerClient!.UserEntity;

        ServerEvent.InvokeEvent(mapMarker);
        cancelled = mapMarker.Cancelled;
    }
}