using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using ProjectM.Network;

namespace NetEvents.Events.Incoming.GiveUpRevive;

internal class GiveUpReviveEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "GiveUpReviveEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var eventArgs = new GiveUpReviveEventArgs();
        
        return eventArgs;
    }
}