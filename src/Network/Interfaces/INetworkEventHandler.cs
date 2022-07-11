namespace NetEvents.Network.Interfaces;

internal interface INetworkEventHandler
{
    string EventName { get; }
    bool Enabled { get; }
}