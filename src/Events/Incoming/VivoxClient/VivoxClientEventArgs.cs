using ProjectM;

namespace NetEvents.Events;

public class VivoxClientEventArgs : AbstractIncomingEventArgs
{
    public VivoxRequestType RequestType { get; }

    internal VivoxClientEventArgs(VivoxRequestType requestType)
    {
        RequestType = requestType;
    }
}