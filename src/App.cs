using ProjectM.Network;
using NetEvents.Utils;
using UnityEngine;
using NetEvents.Network;
using NetEvents.Events;

namespace NetEvents;

public class App : MonoBehaviour
{
    public void Start()
    {
        Plugin.Logger?.LogDebug("App Start");
        
        ServerEvent.DropItemAtSlot += testHandler;
    }

    public void testHandler(DropItemAtSlotEventArgs e)
    {
        var em = WorldUtils.GetWorld().EntityManager;
        var user = em.GetComponentData<User>(e.UserEntity);

        Plugin.Logger?.LogDebug($"User {user.CharacterName} dropped item at slot {e.Slot}");
    }

}
