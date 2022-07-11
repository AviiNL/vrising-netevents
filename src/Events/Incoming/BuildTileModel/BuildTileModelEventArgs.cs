using ProjectM;
using ProjectM.Network;
using ProjectM.Tiles;
using Unity.Mathematics;

namespace NetEvents.Events;

public class BuildTileModelEventArgs : AbstractEventArgs
{
    public override EventDirection EventDirection => EventDirection.ClientServer;
    
    public PrefabGUID PrefabGuid { get; }
    public float3 SpawnPosition { get; }
    public TileRotation SpawnTileRotation { get; }
    public NetworkId TransformedEntity { get; }

    public BuildTileModelEventArgs(PrefabGUID prefabGuid, float3 spawnPosition, TileRotation spawnTileRotation, NetworkId transformedEntity)
    {
        PrefabGuid = prefabGuid;
        SpawnPosition = spawnPosition;
        SpawnTileRotation = spawnTileRotation;
        TransformedEntity = transformedEntity;
    }
}