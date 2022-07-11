using NetEvents.Network;
using NetEvents.Network.Interfaces;
using NetEvents.Network.Models;
using ProjectM;

namespace NetEvents.Events.Incoming.ActivateVBloodAbility;

internal class ActivateVBloodAbilityEventHandler : IIncomingNetworkEventHandler
{
    public string EventName => "ActivateVBloodAbilityEvent";
    public bool Enabled => true;

    public void Handle(IncomingNetworkEvent networkEvent, out bool cancelled)
    {

        var prefabGUID = new PrefabGUID((int)networkEvent.NetBufferIn.ReadUInt32());
        var primarySlot = networkEvent.NetBufferIn.ReadBoolean();

        var activateVBloodAbilityEvent = new ActivateVBloodAbilityEventArgs(
            prefabGUID,
            primarySlot
        );
        
        activateVBloodAbilityEvent.UserEntity = networkEvent.ServerClient!.UserEntity;

        ServerEvent.InvokeEvent(activateVBloodAbilityEvent);
        cancelled = activateVBloodAbilityEvent.Cancelled;
    }
}