using System;

namespace KartRider.Common.Security;

public static class KRPacketCrypto
{
    public static uint HashDecrypt(byte[] pData, uint nLength, uint nKey)
    {
        uint num = nKey ^ 0x14B307C8u;
        uint num2 = nKey ^ 0x8CBF12ACu;
        uint num3 = nKey ^ 0x240397C1u;
        uint num4 = nKey ^ 0xF3BD29C0u;
        int num5 = 0;
        uint num6 = 0u;
        int num7 = 0;
        for (num7 = 0; num7 < nLength >> 4; num7++)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(BitConverter.ToUInt32(pData, num5) ^ num), 0, pData, num5, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(BitConverter.ToUInt32(pData, num5 + 4) ^ num2), 0, pData, num5 + 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(BitConverter.ToUInt32(pData, num5 + 8) ^ num3), 0, pData, num5 + 8, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(BitConverter.ToUInt32(pData, num5 + 12) ^ num4), 0, pData, num5 + 12, 4);
            num6 ^= BitConverter.ToUInt32(pData, num5 + 12) ^ BitConverter.ToUInt32(pData, num5 + 8) ^ BitConverter.ToUInt32(pData, num5 + 4) ^ BitConverter.ToUInt32(pData, num5);
            num5 += 16;
        }

        num7 *= 16;
        num5 = 0;
        byte[] bytes = BitConverter.GetBytes(num);
        byte[] bytes2 = BitConverter.GetBytes(num2);
        byte[] bytes3 = BitConverter.GetBytes(num3);
        byte[] bytes4 = BitConverter.GetBytes(num4);
        byte[] array = new byte[16];
        Buffer.BlockCopy(bytes, 0, array, 0, 4);
        Buffer.BlockCopy(bytes2, 0, array, 4, 4);
        Buffer.BlockCopy(bytes3, 0, array, 8, 4);
        Buffer.BlockCopy(bytes4, 0, array, 12, 4);
        while (num7 < nLength)
        {
            pData[num7] ^= array[num5];
            num6 ^= (uint)(pData[num7] << num5);
            num7++;
            num5++;
        }

        return num6;
    }

    public static uint HashEncrypt(byte[] pData, uint nLength, uint nKey)
    {
        uint num = nKey ^ 0x14B307C8u;
        uint num2 = nKey ^ 0x8CBF12ACu;
        uint num3 = nKey ^ 0x240397C1u;
        uint num4 = nKey ^ 0xF3BD29C0u;
        int num5 = 0;
        uint num6 = 0u;
        int num7 = 0;
        for (num7 = 0; num7 < nLength >> 4; num7++)
        {
            num6 ^= BitConverter.ToUInt32(pData, num5 + 12) ^ BitConverter.ToUInt32(pData, num5 + 8) ^ BitConverter.ToUInt32(pData, num5 + 4) ^ BitConverter.ToUInt32(pData, num5);
            Buffer.BlockCopy(BitConverter.GetBytes(BitConverter.ToUInt32(pData, num5) ^ num), 0, pData, num5, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(BitConverter.ToUInt32(pData, num5 + 4) ^ num2), 0, pData, num5 + 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(BitConverter.ToUInt32(pData, num5 + 8) ^ num3), 0, pData, num5 + 8, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(BitConverter.ToUInt32(pData, num5 + 12) ^ num4), 0, pData, num5 + 12, 4);
            num5 += 16;
        }

        num7 *= 16;
        num5 = 0;
        byte[] bytes = BitConverter.GetBytes(num);
        byte[] bytes2 = BitConverter.GetBytes(num2);
        byte[] bytes3 = BitConverter.GetBytes(num3);
        byte[] bytes4 = BitConverter.GetBytes(num4);
        byte[] array = new byte[16];
        Buffer.BlockCopy(bytes, 0, array, 0, 4);
        Buffer.BlockCopy(bytes2, 0, array, 4, 4);
        Buffer.BlockCopy(bytes3, 0, array, 8, 4);
        Buffer.BlockCopy(bytes4, 0, array, 12, 4);
        while (num7 < nLength)
        {
            num6 ^= (uint)(pData[num7] << num5);
            pData[num7] ^= array[num5];
            num7++;
            num5++;
        }

        return num6;
    }
}