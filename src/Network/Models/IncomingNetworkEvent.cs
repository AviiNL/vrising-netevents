using NetEvents.Utils;
using ProjectM;
using Stunlock.Network;

namespace NetEvents.Network.Models;

internal class IncomingNetworkEvent
{
    public IncomingNetworkEvent(NetBufferIn netBufferIn, int eventId, NetworkEvents_Serialize.DeserializeNetworkEventParams eventParams)
    {
        NetBufferIn = netBufferIn;
        EventId = eventId;
        EventParams = eventParams;
        FromUserIndex = eventParams.FromUserIndex;
        var serverBootstrap = WorldUtils.GetWorld().GetExistingSystem<ServerBootstrapSystem>()!;
        ServerClient = serverBootstrap._ApprovedUsersLookup[FromUserIndex];
    }

    internal NetBufferIn NetBufferIn { get; }
    internal int EventId { get; }
    public NetworkEvents_Serialize.DeserializeNetworkEventParams EventParams { get; }
    internal int FromUserIndex { get; }
    internal ServerBootstrapSystem.ServerClient ServerClient { get; }
}