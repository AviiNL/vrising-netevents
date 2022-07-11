using NetEvents.Utils;
using ProjectM.Network;
using Unity.Entities;

namespace NetEvents.Events.Outgoing.UserKillServer;

public class UserKillServerEventArgs : AbstractEventArgs
{
    public Entity Killer;
    public Entity Died;

    public UserKillServerEventArgs(Entity Killer, Entity Died)
    {
        this.Killer = Killer;
        this.Died = Died;
    }
}