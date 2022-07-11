using Unity.Entities;

namespace NetEvents.Events;

public abstract class AbstractEventArgs
{
    public abstract EventDirection EventDirection { get; }
    public Entity UserEntity { get; internal set; }
    public bool Cancelled { get; set; } = false;
}
