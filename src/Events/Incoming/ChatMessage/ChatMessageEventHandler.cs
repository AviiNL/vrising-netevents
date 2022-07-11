using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;

namespace NetEvents.Events.Incoming.ChatMessage;

internal class ChatMessageEventHandler : IIncomingNetworkEventHandler
{
    public string EventName => "ChatMessageEvent";
    public bool Enabled => true;

    public void Handle(IncomingNetworkEvent networkEvent, out bool cancelled)
    {
        var chatMessage = ChatMessageEventArgs.From(networkEvent.NetBufferIn);
        chatMessage.UserEntity = networkEvent.ServerClient!.UserEntity;

        ServerEvent.InvokeEvent(chatMessage);
        cancelled = chatMessage.Cancelled;
    }
}