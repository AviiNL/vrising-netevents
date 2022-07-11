using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Network;

internal static class NetworkEventManager
{
    private static readonly Dictionary<string, IIncomingNetworkEventHandler> IncomingEventHandlers = new();
    private static readonly Dictionary<string, IOutgoingNetworkEventHandler> OutgoingEventHandlers = new();

    internal static void HandleEvent(IncomingNetworkEvent networkEvent, out bool cancelled)
    {
        cancelled = false;
        var eventName = NetworkEvents.GetNetworkEventName(networkEvent.EventId);
        if (IncomingEventHandlers.TryGetValue(eventName, out var eventHandler) && eventHandler.Enabled)
        {
            eventHandler.Handle(networkEvent, out cancelled);
        }
    }

    internal static void HandleEvent(OutgoingNetworkEvent networkEvent, out bool cancelled)
    {
        cancelled = false;
        var eventName = NetworkEvents.GetNetworkEventName(networkEvent.EventId);
        if (OutgoingEventHandlers.TryGetValue(eventName, out var eventHandler) && eventHandler.Enabled)
        {
            eventHandler.Handle(networkEvent, out cancelled);
        }
    }

    internal static void RegisterEvents(Type? type = null)
    {
        type ??= typeof(NetworkEventManager);
        var assembly = Assembly.GetAssembly(type);

        var incomingType = typeof(IIncomingNetworkEventHandler);
        var incomingTypes = assembly.GetTypes().Where(t => incomingType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
        foreach (var incomingEventType in incomingTypes)
        {
            var instance = (IIncomingNetworkEventHandler)Activator.CreateInstance(incomingEventType);
            IncomingEventHandlers[instance.EventName] = instance;
        }

        var outgoingType = typeof(IOutgoingNetworkEventHandler);
        var outgoingTypes = assembly.GetTypes().Where(t => outgoingType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
        foreach (var outgoingEventType in outgoingTypes)
        {
            var instance = (IOutgoingNetworkEventHandler)Activator.CreateInstance(outgoingEventType);
            OutgoingEventHandlers[instance.EventName] = instance;
        }

    }
}