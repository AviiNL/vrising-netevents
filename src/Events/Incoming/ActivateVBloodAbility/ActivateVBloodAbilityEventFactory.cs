using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using ProjectM;

namespace NetEvents.Events.Incoming.ActivateVBloodAbility;

internal class ActivateVBloodAbilityEventFactory : IIncomingNetworkEventFactory
{
    public string EventName => "ActivateVBloodAbilityEvent";
    public bool Enabled => true;

    public AbstractEventArgs Build(IncomingNetworkEvent networkEvent)
    {
        var prefabGUID = new PrefabGUID((int)networkEvent.NetBufferIn.ReadUInt32());
        var primarySlot = networkEvent.NetBufferIn.ReadBoolean();

        var activateVBloodAbilityEvent = new ActivateVBloodAbilityEventArgs(
            prefabGUID,
            primarySlot
        );
        
        activateVBloodAbilityEvent.UserEntity = networkEvent.ServerClient!.UserEntity;

        return activateVBloodAbilityEvent;
    }
}