using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using ProjectM.Network;

namespace NetEvents.Events.Incoming.ChatMessage;

internal class ChatMessageEventHandler : IIncomingNetworkEventFactory
{
    public string EventName => "ChatMessageEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var netBufferIn = networkEvent.NetBufferIn;

        var messageType = (ChatMessageType)netBufferIn.ReadByte();
        var messageText = netBufferIn.ReadFixedString512();
        NetworkId? receiverEntity = null;
        
        if (messageType == ChatMessageType.Whisper)
        {
            receiverEntity = netBufferIn.ReadNetworkId();
        }

        var chatMessage = new ChatMessageEventArgs(messageType, messageText, receiverEntity);
        
        chatMessage.UserEntity = networkEvent.ServerClient!.UserEntity;

        return chatMessage;
    }
}