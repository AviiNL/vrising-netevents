namespace NetEvents.Network.Interfaces;

public interface INetworkEventFactory
{
    string EventName { get; }
    bool Enabled { get; }
}