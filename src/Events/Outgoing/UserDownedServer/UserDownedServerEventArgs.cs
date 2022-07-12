using ProjectM;

namespace NetEvents.Events;

public class UserDownedServerEventArgs : AbstractEventArgs
{
    public PlayerCharacter Target;
    public PlayerCharacter Source;

    internal UserDownedServerEventArgs(PlayerCharacter Target, PlayerCharacter Source)
    {
        this.Target = Target;
        this.Source = Source;
    }
}