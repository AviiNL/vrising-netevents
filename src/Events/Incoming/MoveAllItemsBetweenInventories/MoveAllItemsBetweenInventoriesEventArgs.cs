using ProjectM.Network;

namespace NetEvents.Events;

public class MoveAllItemsBetweenInventoriesEventArgs : AbstractIncomingEventArgs
{
    public NetworkId FromInventory { get; }
    public NetworkId ToInventory { get; }

    public MoveAllItemsBetweenInventoriesEventArgs(NetworkId fromInventory, NetworkId toInventory)
    {
        FromInventory = fromInventory;
        ToInventory = toInventory;
    }
}