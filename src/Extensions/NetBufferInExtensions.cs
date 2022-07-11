using ProjectM.Network;
using Stunlock.Network;

// namespace intentionally omitted

public static class NetBufferInExtensions
{
    public static NetworkId ReadNetworkId(this NetBufferIn self)
    {
        var index = self.ReadRangedInteger(0, 0xffffe);
        var generation = self.ReadByte();

        return new NetworkId() {
            Index = index,
            Generation = generation
        };
    }
}