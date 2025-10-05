using System;

namespace KartRider.Common.Security;

public class KRCrypto
{
    public static byte[] ApplyCrypto(byte[] input, uint key)
    {
        byte[] array = new byte[input.Length];
        Buffer.BlockCopy(input, 0, array, 0, input.Length);
        int num = 0;
        uint[] array2 = new uint[17];
        byte[] array3 = new byte[68];
        array2[0] = key ^ 0x8473FBC1u;
        for (num = 1; num < 16; num++)
        {
            array2[num] = array2[num - 1] - 2072773695;
        }

        for (num = 0; num <= 16; num++)
        {
            Buffer.BlockCopy(BitConverter.GetBytes(array2[num]), 0, array3, num * 4, 4);
        }

        for (num = 0; num + 64 <= array.Length; num += 64)
        {
            for (int i = 0; i < 16; i++)
            {
                Buffer.BlockCopy(BitConverter.GetBytes(array2[i] ^ BitConverter.ToUInt32(array, num + 4 * i)), 0, array, num + 4 * i, 4);
            }
        }

        for (int j = num; j < array.Length; j++)
        {
            array[j] ^= array3[j - num];
        }

        return array;
    }
}