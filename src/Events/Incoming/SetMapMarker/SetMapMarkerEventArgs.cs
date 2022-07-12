using Unity.Mathematics;

namespace NetEvents.Events;

public class SetMapMarkerEventArgs : AbstractIncomingEventArgs
{    
    public float2 Position { get; private set; }

    public SetMapMarkerEventArgs(float2 position)
    {
        Position = position;
    }
}
