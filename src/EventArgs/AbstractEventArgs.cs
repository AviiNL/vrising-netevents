using Unity.Entities;

namespace NetEvents.EventArgs;

public abstract class AbstractEventArgs
{
    public Entity UserEntity { get; set; }
    public bool Cancelled { get; set; } = false;
}