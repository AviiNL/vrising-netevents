namespace NetEvents.Events;

public class AdminAuthEventArgs : AbstractIncomingEventArgs
{
    public override EventDirection EventDirection => EventDirection.ClientServer;
    
    public AdminAuthEventArgs()
    {
    }
}