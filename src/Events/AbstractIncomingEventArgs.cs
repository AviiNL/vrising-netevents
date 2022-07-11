using Unity.Entities;

namespace NetEvents.Events;

public abstract class AbstractIncomingEventArgs : AbstractEventArgs
{
    public Entity UserEntity { get; internal set; }
}