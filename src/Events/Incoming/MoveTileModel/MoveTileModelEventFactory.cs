using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using ProjectM.Tiles;
using Unity.Mathematics;

namespace NetEvents.Events.Incoming.MoveTileModel;

internal class MoveTileModelEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "MoveTileModelEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var networkId = networkEvent.NetBufferIn.ReadNetworkId();
        var x = networkEvent.NetBufferIn.ReadFloat();
        var y = networkEvent.NetBufferIn.ReadFloat();
        var z = networkEvent.NetBufferIn.ReadFloat();

        var rotation = (TileRotation)networkEvent.NetBufferIn.ReadByte();

        var eventArgs = new MoveTileModelEventArgs(
            networkId,
            new float3(x, y, z),
            rotation
        );
        
        return eventArgs;
    }
}