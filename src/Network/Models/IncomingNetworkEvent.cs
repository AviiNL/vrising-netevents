using NetEvents.Utils;
using ProjectM;
using Stunlock.Network;

namespace NetEvents.Network.Models;

public class IncomingNetworkEvent
{
    internal IncomingNetworkEvent(NetBufferIn netBufferIn, int eventId, NetworkEvents_Serialize.DeserializeNetworkEventParams eventParams)
    {
        NetBufferIn = netBufferIn;
        EventId = eventId;
        EventParams = eventParams;
        FromUserIndex = eventParams.FromUserIndex;
        var serverBootstrap = WorldUtils.GetWorld().GetExistingSystem<ServerBootstrapSystem>()!;
        ServerClient = serverBootstrap._ApprovedUsersLookup[FromUserIndex];
    }

    public NetBufferIn NetBufferIn { get; }
    public int EventId { get; }
    public NetworkEvents_Serialize.DeserializeNetworkEventParams EventParams { get; }
    public int FromUserIndex { get; }
    public ServerBootstrapSystem.ServerClient ServerClient { get; }
}