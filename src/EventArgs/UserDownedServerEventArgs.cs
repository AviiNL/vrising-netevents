using NetEvents.Utils;
using ProjectM;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;

namespace NetEvents.EventArgs;

public class UserDownedServerEventArgs : AbstractEventArgs
{
    public PlayerCharacter Target;
    public PlayerCharacter Source;

    public UserDownedServerEventArgs(PlayerCharacter Target, PlayerCharacter Source)
    {
        this.Target = Target;
        this.Source = Source;
    }

    internal static UserDownedServerEventArgs From(EntityManager em, Entity entity)
    {
        var networkIdSystem = WorldUtils.GetWorld().GetExistingSystem<NetworkIdSystem>();

        var userDownedServerEventData = em.GetComponentData<UserDownedServerEvent>(entity);

        var targetEntity = networkIdSystem._NetworkIdToEntityMap[userDownedServerEventData.Target];
        var sourceEntity = networkIdSystem._NetworkIdToEntityMap[userDownedServerEventData.Source];

        var targetPlayerCharacter = em.GetComponentData<PlayerCharacter>(targetEntity);
        var sourcePlayerCharacter = em.GetComponentData<PlayerCharacter>(sourceEntity);

        return new UserDownedServerEventArgs(
            targetPlayerCharacter,
            sourcePlayerCharacter
        );
    }
}