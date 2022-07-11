namespace NetEvents.Events;

public class DeauthAdminEventArgs : AbstractEventArgs
{
    public override EventDirection EventDirection => EventDirection.ClientServer;
    
    public DeauthAdminEventArgs()
    {
    }
}