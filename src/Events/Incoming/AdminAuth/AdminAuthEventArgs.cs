namespace NetEvents.Events;

public class AdminAuthEventArgs : AbstractEventArgs
{
    public override EventDirection EventDirection => EventDirection.ClientServer;
    
    public AdminAuthEventArgs()
    {
    }
}