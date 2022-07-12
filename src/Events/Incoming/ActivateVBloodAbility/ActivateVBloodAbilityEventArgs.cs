using ProjectM;

namespace NetEvents.Events;

public class ActivateVBloodAbilityEventArgs : AbstractIncomingEventArgs
{    public PrefabGUID AbilityGUID {get;}
    public bool PrimarySlot {get;}

    public ActivateVBloodAbilityEventArgs(PrefabGUID abilityGUID, bool primarySlot)
    {
        AbilityGUID = abilityGUID;
        PrimarySlot = primarySlot;
    }
}