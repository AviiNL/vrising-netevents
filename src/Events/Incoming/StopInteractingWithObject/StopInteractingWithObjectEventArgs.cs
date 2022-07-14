using ProjectM.Network;

namespace NetEvents.Events;

public class StopInteractingWithObjectEventArgs : AbstractIncomingEventArgs
{
    public NetworkId Target { get; }

    internal StopInteractingWithObjectEventArgs(NetworkId target)
    {
        Target = target;
    }
}