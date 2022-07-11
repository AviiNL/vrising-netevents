using Unity.Entities;

namespace NetEvents.Events;

public abstract class AbstractEventArgs
{
    public abstract EventDirection EventDirection { get; }
    public bool Cancelled { get; set; } = false;
}
