using ProjectM.Network;
using NetEvents.Utils;
using UnityEngine;
using NetEvents.Network;
using NetEvents.Events;
using ProjectM;

namespace NetEvents;

public class App : MonoBehaviour
{
    public void Start()
    {
        Plugin.Logger?.LogDebug("App Start");
        
        ServerEvent.KillEvent += testHandler;
        ServerEvent.UserDownedServer += userDown;
    }

    public void userDown(UserDownedServerEventArgs e)
    {
        var em = WorldUtils.GetWorld().EntityManager;
        var target = em.GetComponentData<PlayerCharacter>(e.Target);
        var targetUser = em.GetComponentData<User>(target.UserEntity._Entity);

        if (e.Target == e.Source)
        {
            Plugin.Logger?.LogDebug($"{targetUser.CharacterName} killed themselves");
            return;
        }

        if (!em.HasComponent<PlayerCharacter>(e.Source)) {
            Plugin.Logger?.LogDebug("Source player character not found, killed by NPC or environment?");
            return;
        }

        Plugin.Logger?.LogDebug($"{targetUser.CharacterName} died.");
    }

    public void testHandler(KillEventArgs e)
    {
        var em = WorldUtils.GetWorld().EntityManager;
        var user = em.GetComponentData<User>(e.UserEntity);

        Plugin.Logger?.LogDebug($"User {user.CharacterName} killed {e.NetworkId} ({e.Who} - {e.Filter})");
    }

}
