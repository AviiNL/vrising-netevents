using ProjectM.Network;

namespace NetEvents.Events;

public class SortAllItemsEventArgs : AbstractIncomingEventArgs
{

    public NetworkId Inventory {get;}

    internal SortAllItemsEventArgs(NetworkId inventory) {
        this.Inventory = inventory;
    }
    
}