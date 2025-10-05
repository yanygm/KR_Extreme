using System;
using System.Text;

namespace KartRider.IO;

public abstract class PacketBase : IDisposable
{
    public abstract int Length { get; }

    public abstract int Position { get; set; }

    public abstract byte[] ToArray();

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        byte[] array = ToArray();
        foreach (byte b in array)
        {
            stringBuilder.AppendFormat("{0:X2} ", b);
        }

        return stringBuilder.ToString();
    }

    public virtual void Dispose()
    {
    }
}