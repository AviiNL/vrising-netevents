using ProjectM.Network;

namespace NetEvents.Events;

public class CharacterRespawnEventArgs : AbstractIncomingEventArgs
{
    public SpawnLocationType SpawnLocationType;
    public uint SpawnOptionIndex;
    public NetworkId SpawnLocationIcon;

    internal CharacterRespawnEventArgs(SpawnLocationType spawnLocationType, uint spawnOptionIndex, NetworkId spawnLocationIcon)
    {
        SpawnLocationType = spawnLocationType;
        SpawnOptionIndex = spawnOptionIndex;
        SpawnLocationIcon = spawnLocationIcon;
    }
}