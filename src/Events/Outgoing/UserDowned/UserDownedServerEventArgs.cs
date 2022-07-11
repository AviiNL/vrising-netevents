using NetEvents.Utils;
using ProjectM;
using ProjectM.Network;
using Unity.Entities;

namespace NetEvents.Events.Outgoing.UserDowned;

public class UserDownedServerEventArgs : AbstractEventArgs
{
    public PlayerCharacter Target;
    public PlayerCharacter Source;

    public UserDownedServerEventArgs(PlayerCharacter Target, PlayerCharacter Source)
    {
        this.Target = Target;
        this.Source = Source;
    }
}