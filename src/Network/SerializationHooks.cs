using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BepInEx.IL2CPP.Hook;
using ProjectM;
using ProjectM.Network;
using NetEvents.Utils;
using Stunlock.Network;
using static NetworkEvents_Serialize;
using static ProjectM.Network.ClanEvents_Client;
using static ProjectM.Network.ClanEvents_Server;
using static ProjectM.Network.InteractEvents_Client;
using static ProjectM.TeleportEvents_ToServer;
using NetEvents.Network.Models;
using Unity.Entities;

namespace NetEvents.Network;

/// Contains the serialization hooks for custom packets.
internal static class SerializationHooks
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void SerializeEvent(IntPtr entityManager, UInt64 networkEventType, UInt64 netBufferOut, IntPtr entity);
    public static SerializeEvent? SerializeOriginal;
    
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void DeserializeEvent(IntPtr commandBuffer, IntPtr netBuffer, DeserializeNetworkEventParams eventParams);
    public static DeserializeEvent? DeserializeOriginal;

    private static FastNativeDetour? _serializeDetour;
    private static FastNativeDetour? _deserializeDetour;

    public static void Initialize()
    {
        _serializeDetour = NativeHookUtil.Detour(typeof(NetworkEvents_Serialize), "SerializeEvent", SerializeHook, out SerializeOriginal);
        _deserializeDetour = NativeHookUtil.Detour(typeof(NetworkEvents_Serialize), "DeserializeEvent", DeserializeHook, out DeserializeOriginal);
    }

    public static void Uninitialize()
    {
        _serializeDetour?.Dispose();
        _deserializeDetour?.Dispose();
    }

    // Outgoing events (Server->Client)
    public static unsafe void SerializeHook(IntPtr entityManager, UInt64 networkEventType, UInt64 netBufferOut, IntPtr entity)
    {
        var eventType = *(NetworkEventType*)&networkEventType;

        var eventId = eventType.EventId;

        var em = *(EntityManager*)&entityManager;
        var realEntity = *(Entity*)&entity;

        var networkEvent = new OutgoingNetworkEvent(eventType, eventId, em, realEntity);

        if (!NetworkEventManager.HandleEvent(networkEvent, out var cancelled)) {
            Plugin.Logger?.LogError($"Unhandled outgoing event: {NetworkEvents.GetNetworkEventName(eventId)}");
        }

        if (cancelled)
        {
            return;
        }

        SerializeOriginal!(entityManager, networkEventType, netBufferOut, entity);
    }

    // Incoming Events (Client->Server)
    public static void DeserializeHook(IntPtr commandBuffer, IntPtr netBuffer, DeserializeNetworkEventParams eventParams)
    {
        var netBufferIn = new NetBufferIn(new IntPtr((long)(netBuffer - 0x10)));
        var eventId = netBufferIn.ReadInt32();

        var networkEvent = new IncomingNetworkEvent(netBufferIn, eventId, eventParams);

        if (!NetworkEventManager.HandleEvent(networkEvent, out var cancelled)) {
            Plugin.Logger?.LogError($"Unhandled incoming event: {NetworkEvents.GetNetworkEventName(eventId)}");
        }
        
        if (cancelled)
        {
            return;
        }

        netBufferIn.m_readPosition = 72;
        DeserializeOriginal!(commandBuffer, netBuffer, eventParams);
    }

}