using Unity.Entities;

namespace NetEvents.Events;

public abstract class AbstractEventArgs
{
    public Entity UserEntity { get; set; }
    public bool Cancelled { get; set; } = false;
}