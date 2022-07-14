using ProjectM;
using ProjectM.Network;

namespace NetEvents.Events;

public class UseDefaultActionEventArgs : AbstractIncomingEventArgs
{
    public PrefabGUID Action;
    public bool ExitOnSameForm;

    internal UseDefaultActionEventArgs(PrefabGUID action, bool exitOnSameForm)
    {
        Action = action;
        ExitOnSameForm = exitOnSameForm;
    }
}