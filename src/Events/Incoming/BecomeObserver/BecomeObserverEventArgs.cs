namespace NetEvents.Events;

public class BecomeObserverEventArgs : AbstractIncomingEventArgs
{    
    public int Mode {get;}

    internal BecomeObserverEventArgs(int mode)
    {
        Mode = mode;
    }
}