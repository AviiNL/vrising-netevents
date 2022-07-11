namespace NetEvents.Events.Incoming.DeauthAdmin;

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