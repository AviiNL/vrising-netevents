using ProjectM.Network;
using Unity.Collections;

namespace NetEvents.EventArgs;

public class AdminAuthEventArgs : AbstractEventArgs
{
    public AdminAuthEventArgs()
    {
    }

    internal static AdminAuthEventArgs From()
    {
        return new AdminAuthEventArgs();
    }
}