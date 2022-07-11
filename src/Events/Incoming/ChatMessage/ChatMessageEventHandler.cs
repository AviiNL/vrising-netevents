using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using ProjectM.Network;

namespace NetEvents.Events.Incoming.ChatMessage;

internal class ChatMessageEventHandler : IIncomingNetworkEventHandler
{
    public string EventName => "ChatMessageEvent";
    public bool Enabled => true;

    public void Handle(IncomingNetworkEvent networkEvent, out bool cancelled)
    {
        var netBufferIn = networkEvent.NetBufferIn;

        var messageType = (ChatMessageType)netBufferIn.ReadByte();
        var messageText = netBufferIn.ReadFixedString512();
        NetworkId? receiverEntity = null;
        
        if (messageType == ChatMessageType.Whisper)
        {
            receiverEntity = NetworkSync.ReadNetworkId(ref netBufferIn);
        }

        var chatMessage = new ChatMessageEventArgs(messageType, messageText, receiverEntity);
        
        chatMessage.UserEntity = networkEvent.ServerClient!.UserEntity;

        ServerEvent.InvokeEvent(chatMessage);
        cancelled = chatMessage.Cancelled;
    }
}