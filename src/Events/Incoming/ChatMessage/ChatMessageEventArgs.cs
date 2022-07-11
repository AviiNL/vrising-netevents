using ProjectM.Network;
using Unity.Collections;

namespace NetEvents.Events;

public class ChatMessageEventArgs : AbstractIncomingEventArgs
{
    public override EventDirection EventDirection => EventDirection.ClientServer;
    
    public ChatMessageType MessageType { get; private set; }
    public FixedString512 MessageText { get; private set; }
    public NetworkId? ReceiverEntity { get; private set; }

    public ChatMessageEventArgs(ChatMessageType messageType, FixedString512 messageText, NetworkId? receiverEntity)
    {
        MessageType = messageType;
        MessageText = messageText;
        ReceiverEntity = receiverEntity;
    }
}