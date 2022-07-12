using Unity.Entities;

namespace NetEvents.Events;

public abstract class AbstractEventArgs
{
    public bool Cancelled { get; set; } = false;
}
