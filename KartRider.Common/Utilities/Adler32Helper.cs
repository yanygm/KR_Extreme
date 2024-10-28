using System.Text;

namespace KartRider.Common.Utilities;

public class Adler32Helper
{
    public static int GenerateSimpleAdler32(byte[] bytes)
    {
        uint num = 1u;
        uint num2 = 0u;
        foreach (byte b in bytes)
        {
            num = (num + b) % 65521;
            num2 = (num2 + num) % 65521;
        }

        return (int)((num2 << 16) + num);
    }

    public static uint GenerateAdler32_ASCII(string str, uint a1 = 0u)
    {
        return GenerateAdler32(Encoding.ASCII.GetBytes(str), a1);
    }

    public static uint GenerateAdler32_UNICODE(string str, uint a1 = 0u)
    {
        return GenerateAdler32(Encoding.Unicode.GetBytes(str), a1);
    }

    public static uint GenerateAdler32(byte[] str, uint a1 = 0u)
    {
        int num = 0;
        uint num2 = (uint)str.Length;
        uint num3 = a1 >> 16;
        uint num4 = (ushort)a1;
        if (str.Length == 1)
        {
            int num5 = (int)(str[0] + num4);
            if ((uint)num5 >= 65521u)
            {
                num5 -= 65521;
            }

            int num6 = (int)(num5 + num3);
            if ((uint)num6 >= 65521u)
            {
                num6 -= 65521;
            }

            return (uint)(num5 | (num6 << 16));
        }

        if (str != null)
        {
            if (str.Length >= 16)
            {
                if (str.Length >= 5552)
                {
                    uint num7 = (uint)str.Length / 5552u;
                    do
                    {
                        num2 -= 5552;
                        int num8 = 347;
                        do
                        {
                            int num9 = (int)(str[num] + num4);
                            int num10 = num9 + (int)num3;
                            int num11 = str[num + 1] + num9;
                            int num12 = num11 + num10;
                            int num13 = str[num + 2] + num11;
                            int num14 = num13 + num12;
                            int num15 = str[num + 3] + num13;
                            int num16 = num15 + num14;
                            int num17 = str[num + 4] + num15;
                            int num18 = num17 + num16;
                            int num19 = str[num + 5] + num17;
                            int num20 = num19 + num18;
                            int num21 = str[num + 6] + num19;
                            int num22 = num21 + num20;
                            int num23 = str[num + 7] + num21;
                            int num24 = num23 + num22;
                            int num25 = str[num + 8] + num23;
                            int num26 = num25 + num24;
                            int num27 = str[num + 9] + num25;
                            int num28 = num27 + num26;
                            int num29 = str[num + 10] + num27;
                            int num30 = num29 + num28;
                            int num31 = str[num + 11] + num29;
                            int num32 = num31 + num30;
                            int num33 = str[num + 12] + num31;
                            int num34 = num33 + num32;
                            int num35 = str[num + 13] + num33;
                            int num36 = num35 + num34;
                            int num37 = str[num + 14] + num35;
                            int num38 = num37 + num36;
                            num4 = (uint)(str[num + 15] + num37);
                            num3 = num4 + (uint)num38;
                            num += 16;
                            num8--;
                        }
                        while (num8 != 0);
                        num4 %= 65521;
                        num7--;
                        num3 %= 65521;
                    }
                    while (num7 != 0);
                }

                if (num2 != 0)
                {
                    if (num2 >= 16)
                    {
                        uint num39 = num2 >> 4;
                        do
                        {
                            int num40 = (int)(str[num] + num4);
                            int num41 = num40 + (int)num3;
                            int num42 = str[num + 1] + num40;
                            int num43 = num42 + num41;
                            int num44 = str[num + 2] + num42;
                            int num45 = num44 + num43;
                            int num46 = str[num + 3] + num44;
                            int num47 = num46 + num45;
                            int num48 = str[num + 4] + num46;
                            int num49 = num48 + num47;
                            int num50 = str[num + 5] + num48;
                            int num51 = num50 + num49;
                            int num52 = str[num + 6] + num50;
                            int num53 = num52 + num51;
                            int num54 = str[num + 7] + num52;
                            int num55 = num54 + num53;
                            int num56 = str[num + 8] + num54;
                            int num57 = num56 + num55;
                            int num58 = str[num + 9] + num56;
                            int num59 = num58 + num57;
                            int num60 = str[num + 10] + num58;
                            int num61 = num60 + num59;
                            int num62 = str[num + 11] + num60;
                            int num63 = num62 + num61;
                            int num64 = str[num + 12] + num62;
                            int num65 = num64 + num63;
                            int num66 = str[num + 13] + num64;
                            int num67 = num66 + num65;
                            int num68 = str[num + 14] + num66;
                            int num69 = num68 + num67;
                            num4 = (uint)(str[num + 15] + num68);
                            num2 -= 16;
                            num3 = num4 + (uint)num69;
                            num += 16;
                            num39--;
                        }
                        while (num39 != 0);
                    }

                    while (num2 != 0)
                    {
                        num4 += str[num++];
                        num3 += num4;
                        num2--;
                    }

                    num4 %= 65521;
                    num3 %= 65521;
                }

                return num4 | (num3 << 16);
            }

            if (str.Length != 0)
            {
                do
                {
                    num4 += str[num++];
                    num3 += num4;
                    num2--;
                }
                while (num2 != 0);
            }

            if (num4 >= 65521)
            {
                num4 -= 65521;
            }

            return num4 | (num3 % 65521 << 16);
        }

        return 1u;
    }
}