using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using NetEvents.Utils;
using ProjectM.Network;

namespace NetEvents.Events.Outgoing.UserKillServer;

internal class UserKillServerEventFactory : IOutgoingNetworkEventFactory
{
    public string EventName => "UserKillServerEvent";
    public bool Enabled => true;
    
    public AbstractEventArgs Build(OutgoingNetworkEvent networkEvent)
    {
        var networkIdSystem = WorldUtils.GetWorld().GetExistingSystem<NetworkIdSystem>();

        var userDownedServerEventData = networkEvent.EntityManager.GetComponentData<UserKillServerEvent>(networkEvent.Entity);

        var diedEntity = networkIdSystem._NetworkIdToEntityMap[userDownedServerEventData.Died];
        var killerEntity = networkIdSystem._NetworkIdToEntityMap[userDownedServerEventData.Killer];

        var userKillServer = new UserKillServerEventArgs(
            killerEntity,
            diedEntity
        );
        
        return userKillServer;
    }
}
