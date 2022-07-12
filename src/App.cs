using ProjectM.Network;
using NetEvents.Utils;
using UnityEngine;
using NetEvents.Network;
using ProjectM;
using NetEvents.Events;

namespace NetEvents;

public class App : MonoBehaviour
{
    public void Start()
    {
        Plugin.Logger?.LogDebug("App Start");
        
        ServerEvent.DropInventoryItem += OnDropInventoryItem;
    }

    public void OnDropInventoryItem(DropInventoryItemEventArgs e)
    {
        var em = WorldUtils.GetWorld().EntityManager;
        var user = em.GetComponentData<User>(e.UserEntity);

        Plugin.Logger?.LogDebug($"User {user.CharacterName} dropped item from {e.Inventory} at slot {e.Slot}");
    }

}
