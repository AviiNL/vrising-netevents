using ProjectM.Network;

namespace NetEvents.Events;

public class DropItemAtSlotEventArgs : AbstractIncomingEventArgs
{
    public int Slot { get; }

    public DropItemAtSlotEventArgs(int slotIndex)
    {
        Slot = slotIndex;
    }
}