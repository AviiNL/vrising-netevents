using ProjectM.Network;
using Unity.Collections;

namespace NetEvents.Events;

public class CreateClan_RequestEventArgs : AbstractEventArgs
{
    public override EventDirection EventDirection => EventDirection.ClientServer;
    
    public string ClanName { get; }
    public string ClanMotto { get; }

    public CreateClan_RequestEventArgs(string clanName, string clanMotto)
    {
        ClanName = clanName;
        ClanMotto = clanMotto;
    }
}