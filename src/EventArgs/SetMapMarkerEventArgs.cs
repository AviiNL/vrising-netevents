

using ProjectM.Network;
using Unity.Collections;
using Unity.Mathematics;

namespace NetEvents.EventArgs;

public class SetMapMarkerEventArgs : AbstractEventArgs
{
    public float2 Position {get; private set;}

    public SetMapMarkerEventArgs(float2 position)
    {
        Position = position;
    }
}