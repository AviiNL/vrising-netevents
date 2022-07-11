using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using ProjectM.Network;

namespace NetEvents.Events.Incoming.ChatMessage;

internal class CreateClan_RequestEventHandler : IIncomingNetworkEventHandler
{
    public string EventName => "CreateClan_Request";
    public bool Enabled => true;

    public void Handle(IncomingNetworkEvent networkEvent, out bool cancelled)
    {
        var netBufferIn = networkEvent.NetBufferIn;

        var clanName = netBufferIn.ReadFixedString64();
        var clanMotto = netBufferIn.ReadFixedString64();

        var createClan_Request = new CreateClan_RequestEventArgs(clanName.ToString(), clanMotto.ToString());
        
        createClan_Request.UserEntity = networkEvent.ServerClient!.UserEntity;

        ServerEvent.InvokeEvent(createClan_Request);
        cancelled = createClan_Request.Cancelled;
    }
}