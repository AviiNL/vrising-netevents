using ProjectM.Network;

namespace NetEvents.Events;

public class StartEditTileModelEventArgs : AbstractIncomingEventArgs
{
    public NetworkId Tile { get; }

    internal StartEditTileModelEventArgs(NetworkId tile)
    {
        Tile = tile;
    }
}