using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using ProjectM.Network;

namespace NetEvents.Events.Incoming.Kill;

internal class KillEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "KillEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var who = networkEvent.NetBufferIn.ReadByte();
        var filter = networkEvent.NetBufferIn.ReadByte();
        var networkId = networkEvent.NetBufferIn.ReadNetworkId();

        var killEvent = new KillEventArgs(
            (KillWho)who,
            (KillWhoFilter)filter,
            networkId
        );

        killEvent.UserEntity = networkEvent.UserEntity;

        return killEvent;
    }
}