using Unity.Entities;

namespace NetEvents.Events;

public class UserKillServerEventArgs : AbstractEventArgs
{
    public override EventDirection EventDirection => EventDirection.ServerClient;
    
    public Entity Killer;
    public Entity Died;

    public UserKillServerEventArgs(Entity Killer, Entity Died)
    {
        this.Killer = Killer;
        this.Died = Died;
    }
}