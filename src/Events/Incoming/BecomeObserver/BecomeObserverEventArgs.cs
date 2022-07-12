namespace NetEvents.Events;

public class BecomeObserverEventArgs : AbstractIncomingEventArgs
{    
    public int Mode {get;}

    public BecomeObserverEventArgs(int mode)
    {
        Mode = mode;
    }
}