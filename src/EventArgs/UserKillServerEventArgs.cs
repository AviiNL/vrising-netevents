using NetEvents.Utils;
using ProjectM;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;

namespace NetEvents.EventArgs;

public class UserKillServerEventArgs : AbstractEventArgs
{
    public Entity Killer;
    public Entity Died;

    public UserKillServerEventArgs(Entity Killer, Entity Died)
    {
        this.Killer = Killer;
        this.Died = Died;
    }

    internal static UserKillServerEventArgs From(EntityManager em, Entity entity)
    {
        var networkIdSystem = WorldUtils.GetWorld().GetExistingSystem<NetworkIdSystem>();

        var userDownedServerEventData = em.GetComponentData<UserKillServerEvent>(entity);

        var diedEntity = networkIdSystem._NetworkIdToEntityMap[userDownedServerEventData.Died];
        var killerEntity = networkIdSystem._NetworkIdToEntityMap[userDownedServerEventData.Killer];

        return new UserKillServerEventArgs(
            killerEntity,
            diedEntity
        );
    }
}