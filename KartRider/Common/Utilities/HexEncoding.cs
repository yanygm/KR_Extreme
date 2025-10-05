using System;
using System.Globalization;
using System.Text;

namespace KartRider.Common.Utilities;

public class HexEncoding
{
    public static bool IsHexDigit(char pChar)
    {
        int num = Convert.ToInt32('A');
        int num2 = Convert.ToInt32('0');
        pChar = char.ToUpper(pChar);
        int num3 = Convert.ToInt32(pChar);
        if (num3 >= num && num3 < num + 6)
        {
            return true;
        }

        if (num3 >= num2 && num3 < num2 + 10)
        {
            return true;
        }

        return false;
    }

    private static byte HexToByte(string pHex)
    {
        if (pHex.Length > 2 || pHex.Length <= 0)
        {
            throw new ArgumentException("hex must be 1 or 2 characters in length");
        }

        return byte.Parse(pHex, NumberStyles.HexNumber);
    }

    public static byte[] GetBytes(string pHexString)
    {
        string text = string.Empty;
        for (int i = 0; i < pHexString.Length; i++)
        {
            char pChar = pHexString[i];
            if (IsHexDigit(pChar))
            {
                text += pChar;
            }
        }

        if (text.Length % 2 != 0)
        {
            text = text.Substring(0, text.Length - 1);
        }

        int num = text.Length / 2;
        byte[] array = new byte[num];
        int num2 = 0;
        for (int j = 0; j < array.Length; j++)
        {
            string pHex = new string(new char[2]
            {
                text[num2],
                text[num2 + 1]
            });
            array[j] = HexToByte(pHex);
            num2 += 2;
        }

        return array;
    }

    public static string ToStringFromAscii(byte[] pBytes)
    {
        char[] array = new char[pBytes.Length];
        for (int i = 0; i < pBytes.Length; i++)
        {
            if (pBytes[i] < 32 && pBytes[i] >= 0)
            {
                array[i] = '.';
                continue;
            }

            int num = pBytes[i] & 0xFF;
            array[i] = (char)num;
        }

        return new string(array);
    }

    public static string GetString(byte[] pArray)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (byte b in pArray)
        {
            stringBuilder.Append(b.ToString("X2")).Append(" ");
        }

        return stringBuilder.ToString();
    }
}