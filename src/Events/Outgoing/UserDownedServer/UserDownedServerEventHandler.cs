using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using NetEvents.Utils;
using ProjectM;
using ProjectM.Network;

namespace NetEvents.Events.Outgoing.UserDownedServer
{
    internal class UserDownedServerEventHandler : IOutgoingNetworkEventFactory
    {
        public string EventName => "UserDownedServerEvent";
        public bool Enabled => true;
        
        public AbstractEventArgs Build(OutgoingNetworkEvent networkEvent)
        {
            var networkIdSystem = WorldUtils.GetWorld().GetExistingSystem<NetworkIdSystem>();

            var userDownedServerEventData = networkEvent.EntityManager.GetComponentData<UserDownedServerEvent>(networkEvent.Entity);

            var targetEntity = networkIdSystem._NetworkIdToEntityMap[userDownedServerEventData.Target];
            var sourceEntity = networkIdSystem._NetworkIdToEntityMap[userDownedServerEventData.Source];

            var targetPlayerCharacter = networkEvent.EntityManager.GetComponentData<PlayerCharacter>(targetEntity);
            var sourcePlayerCharacter = networkEvent.EntityManager.GetComponentData<PlayerCharacter>(sourceEntity);

            var userDownedServer = new UserDownedServerEventArgs(
                targetPlayerCharacter,
                sourcePlayerCharacter
            );

            return userDownedServer;
        }
    }
}
