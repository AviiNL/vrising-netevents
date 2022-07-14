using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using ProjectM.Network;

namespace NetEvents.Events.Incoming.CharacterRespawn;

internal class CharacterRespawnEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "CharacterRespawnEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var spawnLocationType = (SpawnLocationType)networkEvent.NetBufferIn.ReadByte();
        var spawnOptionIndex = networkEvent.NetBufferIn.ReadUInt32();
        var spawnLocationIcon = networkEvent.NetBufferIn.ReadNetworkId();

        var eventArgs = new CharacterRespawnEventArgs(
            spawnLocationType,
            spawnOptionIndex,
            spawnLocationIcon
        );
            
        return eventArgs;
    }
}