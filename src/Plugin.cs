using BepInEx;
using BepInEx.IL2CPP;
using NetEvents.Logger.Handler;
using NetEvents.Network;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace NetEvents;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    internal static Plugin? Instance { get; private set; }

    internal static bool IsServer => Application.productName == "VRisingServer";

    internal static NetEvents.Logger.Logger Logger;

    private App? app;

    static Plugin()
    {
        Logger = new NetEvents.Logger.Logger();
        Logger.RegisterLogHandler(new ConsoleLogHandler());
        Logger.RegisterLogHandler(new FileLogHandler());
    }

    public Plugin()
    {
        Instance = this;
    }

    public static void Init()
    {
        if (!IsServer) return;

        Plugin.Logger?.LogMessage("Plugin Ready.");
    }

    public override void Load()
    {
        if (!IsServer) return;

        ClassInjector.RegisterTypeInIl2Cpp<App>();

        SerializationHooks.Initialize();

        app = AddComponent<App>();
    }

    public override bool Unload()
    {
        if (!IsServer) return true;

        SerializationHooks.Uninitialize();

        return true;
    }
}
