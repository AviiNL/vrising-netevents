using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using ProjectM;
using ProjectM.Tiles;
using Unity.Mathematics;

namespace NetEvents.Events.Incoming.BuildTileModel;

internal class BuildTileModelEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "BuildTileModelEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var netBufferIn = networkEvent.NetBufferIn;

        var prefabGuid = new PrefabGUID((int)netBufferIn.ReadUInt32());
        var x = netBufferIn.ReadFloat();
        var y = netBufferIn.ReadFloat();
        var z = netBufferIn.ReadFloat();

        var rotation = (TileRotation)netBufferIn.ReadByte();

        var networkId = netBufferIn.ReadNetworkId();

        var buildTileModelEvent = new BuildTileModelEventArgs(
            prefabGuid,
            new float3(x, y, z),
            rotation,
            networkId
        );

        return buildTileModelEvent;
    }
}