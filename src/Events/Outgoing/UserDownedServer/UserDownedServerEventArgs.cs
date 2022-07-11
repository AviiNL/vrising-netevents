using ProjectM;

namespace NetEvents.Events;

public class UserDownedServerEventArgs : AbstractEventArgs
{
    public override EventDirection EventDirection => EventDirection.ServerClient;
    
    public PlayerCharacter Target;
    public PlayerCharacter Source;

    public UserDownedServerEventArgs(PlayerCharacter Target, PlayerCharacter Source)
    {
        this.Target = Target;
        this.Source = Source;
    }
}