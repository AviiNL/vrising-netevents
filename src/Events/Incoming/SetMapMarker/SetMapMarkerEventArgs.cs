using Unity.Mathematics;

namespace NetEvents.Events.Incoming.SetMapMarker;

public class SetMapMarkerEventArgs : AbstractEventArgs
{
    public float2 Position { get; private set; }

    public SetMapMarkerEventArgs(float2 position)
    {
        Position = position;
    }
}
