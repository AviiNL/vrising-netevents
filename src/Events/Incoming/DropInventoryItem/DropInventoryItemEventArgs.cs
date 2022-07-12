using ProjectM.Network;

namespace NetEvents.Events;

public class DropInventoryItemEventArgs : AbstractIncomingEventArgs
{
    public NetworkId Inventory { get; }
    public uint Slot { get; }

    public DropInventoryItemEventArgs(NetworkId inventory, uint slot)
    {
        Inventory = inventory;
        Slot = slot;
    }
}