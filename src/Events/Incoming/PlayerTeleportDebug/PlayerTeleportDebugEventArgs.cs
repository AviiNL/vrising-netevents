using Unity.Mathematics;
using static ProjectM.Network.PlayerTeleportDebugEvent;

namespace NetEvents.Events;

public class PlayerTeleportDebugEventArgs : AbstractIncomingEventArgs
{
    public float2 Position;
    public TeleportTarget Target;

    internal PlayerTeleportDebugEventArgs(float2 position, TeleportTarget target)
    {
        this.Position = position;
        this.Target = target;
    }
    
}