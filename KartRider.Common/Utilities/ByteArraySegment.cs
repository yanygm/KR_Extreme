namespace KartRider.Common.Utilities;

public sealed class ByteArraySegment
{
    private byte[] mBuffer = null;

    private int mStart = 0;

    private int mLength = 0;

    private bool mEncrypted = true;

    public byte[] Buffer
    {
        get
        {
            return mBuffer;
        }
        set
        {
            mBuffer = value;
        }
    }

    public int Start => mStart;

    public int Length => mLength;

    public bool Encrypted => mEncrypted;

    public ByteArraySegment(byte[] pBuffer, bool pEncrypted)
    {
        mBuffer = pBuffer;
        mLength = mBuffer.Length;
        mEncrypted = pEncrypted;
    }

    public ByteArraySegment(byte[] pBuffer, int pStart, int pLength)
    {
        mBuffer = pBuffer;
        mStart = pStart;
        mLength = pLength;
    }

    public bool Advance(int pLength)
    {
        mStart += pLength;
        mLength -= pLength;
        if (mLength <= 0)
        {
            return true;
        }

        return false;
    }
}