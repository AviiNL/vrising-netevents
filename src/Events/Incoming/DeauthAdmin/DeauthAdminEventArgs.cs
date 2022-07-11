namespace NetEvents.Events;

public class DeauthAdminEventArgs : AbstractIncomingEventArgs
{
    public override EventDirection EventDirection => EventDirection.ClientServer;
    
    public DeauthAdminEventArgs()
    {
    }
}