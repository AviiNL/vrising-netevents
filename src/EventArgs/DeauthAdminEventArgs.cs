using ProjectM.Network;
using Unity.Collections;

namespace NetEvents.EventArgs;

public class DeauthAdminEventArgs : AbstractEventArgs
{
    public DeauthAdminEventArgs()
    {
    }

    internal static DeauthAdminEventArgs From()
    {
        return new DeauthAdminEventArgs();
    }
}