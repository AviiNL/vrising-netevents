using ProjectM.Network;
using Unity.Entities;

namespace NetEvents.Network.Models;

internal class OutgoingNetworkEvent
{
    public OutgoingNetworkEvent(NetworkEventType networkEventType, int eventId, EntityManager entityManager, Entity entity)
    {
        NetworkEventType = networkEventType;
        EventId = eventId;
        EntityManager = entityManager;
        Entity = entity;
    }

    internal NetworkEventType NetworkEventType { get; }
    internal int EventId { get; }
    internal EntityManager EntityManager { get; }
    internal Entity Entity { get; }
}