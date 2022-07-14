using ProjectM.Network;

namespace NetEvents.Events;

public class ShareRefinementEventArgs : AbstractIncomingEventArgs
{
    public NetworkId Station { get; }

    internal ShareRefinementEventArgs(NetworkId station)
    {
        Station = station;
    }
}