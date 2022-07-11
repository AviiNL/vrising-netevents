//using NetEvents.Network;
//using NetEvents.Network.Interfaces;
//using NetEvents.Network.Models;
//using ProjectM.Network;

//namespace NetEvents.Events.Incoming;

//internal class KillEventHandler : IIncomingNetworkEventHandler
//{
//    public string EventName =>  "KillEvent";
//    public bool Enabled => true;

//    public void Handle(IncomingNetworkEvent networkEvent, out bool cancelled)
//    {
//        var who = networkEvent.NetBufferIn.ReadByte();
//        var filter = networkEvent.NetBufferIn.ReadByte();
//        var netBufferIn = networkEvent.NetBufferIn;
//        var userNetworkId = NetworkSync.ReadNetworkId(ref netBufferIn);

//        var killEvent = new KillEventArgs(
//            (KillWho)who,
//            (KillWhoFilter)filter,
//            userNetworkId
//        );
//        killEvent.UserEntity = serverClient!.UserEntity;

//        ServerEvent.InvokeEvent(killEvent);

//        cancelled = killEvent.Cancelled;
//    }
//}