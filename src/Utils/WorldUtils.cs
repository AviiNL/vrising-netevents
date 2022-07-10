using Unity.Entities;

namespace NetEvents.Utils;

public static class WorldUtils
{
    private static World? _world;
    public static World GetWorld()
    {
        foreach(var w in Unity.Entities.World.s_AllWorlds) {
            if (w.Name == "Server") {
                _world = w;
                break;
            }
        }

        return _world!;
    }
}