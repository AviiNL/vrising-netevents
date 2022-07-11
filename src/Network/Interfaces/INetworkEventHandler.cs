namespace NetEvents.Network.Interfaces;

public interface INetworkEventHandler
{
    string EventName { get; }
    bool Enabled { get; }
}