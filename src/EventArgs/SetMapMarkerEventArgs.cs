

using ProjectM.Network;
using Stunlock.Network;
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

    internal static SetMapMarkerEventArgs From(NetBufferIn netBufferIn)
    {
        var x = netBufferIn.ReadFloat();
        var y = netBufferIn.ReadFloat();
        return new SetMapMarkerEventArgs(new float2(x, y));
    }
}