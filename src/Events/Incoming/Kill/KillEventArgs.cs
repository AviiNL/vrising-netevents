using ProjectM.Network;

namespace NetEvents.Events;

public class KillEventArgs : AbstractIncomingEventArgs
{
    public KillWho Who { get; }
    public KillWhoFilter Filter { get; }
    public NetworkId NetworkId { get; }

    internal KillEventArgs(KillWho who, KillWhoFilter filter, NetworkId networkId)
    {
        Who = who;
        Filter = filter;
        NetworkId = networkId;
    }
}