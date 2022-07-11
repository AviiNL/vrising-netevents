namespace NetEvents.Events.Incoming.AdminAuth;

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