using System;
using System.Xml;

namespace KartNew.Utilities;

public class TimeUtil
{
    private static ushort[] _yearTable = new ushort[181]
    {
        0, 365, 730, 1095, 1460, 1826, 2191, 2556, 2921, 3287,
        3652, 4017, 4382, 4748, 5113, 5478, 5843, 6209, 6574, 6939,
        7304, 7670, 8035, 8400, 8765, 9131, 9496, 9861, 10226, 10592,
        10957, 11322, 11687, 12053, 12418, 12783, 13148, 13514, 13879, 14244,
        14609, 14975, 15340, 15705, 16070, 16436, 16801, 17166, 17531, 17897,
        18262, 18627, 18992, 19358, 19723, 20088, 20453, 20819, 21184, 21549,
        21914, 22280, 22645, 23010, 23375, 23741, 24106, 24471, 24836, 25202,
        25567, 25932, 26297, 26663, 27028, 27393, 27758, 28124, 28489, 28854,
        29219, 29585, 29950, 30315, 30680, 31046, 31411, 31776, 32141, 32507,
        32872, 33237, 33602, 33968, 34333, 34698, 35063, 35429, 35794, 36159,
        36524, 36890, 37255, 37620, 37985, 38351, 38716, 39081, 39446, 39812,
        40177, 40542, 40907, 41273, 41638, 42003, 42368, 42734, 43099, 43464,
        43829, 44195, 44560, 44925, 45290, 45656, 46021, 46386, 46751, 47117,
        47482, 47847, 48212, 48578, 48943, 49308, 49673, 50039, 50404, 50769,
        51134, 51500, 51865, 52230, 52595, 52961, 53326, 53691, 54056, 54422,
        54787, 55152, 55517, 55883, 56248, 56613, 56978, 57344, 57709, 58074,
        58439, 58805, 59170, 59535, 59900, 60266, 60631, 60996, 61361, 61727,
        62092, 62457, 62822, 63188, 63553, 63918, 64283, 64649, 65014, 65379,
        65535
    };

    private static ushort[] _monthTable = new ushort[13]
    {
        0, 31, 59, 90, 120, 151, 181, 212, 243, 273,
        304, 334, 365
    };

    private static ushort[] _monthLeapYearTable = new ushort[13]
    {
        0, 31, 60, 91, 121, 152, 182, 213, 244, 274,
        305, 335, 366
    };

    public static int GetYear(ref int date)
    {
        int num = 0;
        int num2 = 180;
        int num3 = 0;
        while (num < num2)
        {
            num3 = (num + num2) / 2;
            if (_yearTable[num3] <= date)
            {
                if (_yearTable[num3 + 1] > date)
                {
                    date -= _yearTable[num3];
                    return num3;
                }

                num = num3 + 1;
            }
            else
            {
                num2 = (num + num2) / 2;
            }
        }

        date += 157;
        return 179;
    }

    public static bool IsLeapYear(int year)
    {
        return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
    }

    public static int GetMonth(ref int date, bool leapYear)
    {
        int i = 0;
        if (leapYear)
        {
            for (; i < 12 && (_monthLeapYearTable[i] >= date || date > _monthLeapYearTable[i + 1]); i++)
            {
            }

            date -= _monthLeapYearTable[i];
        }
        else
        {
            for (; i < 12 && (_monthTable[i] >= date || date > _monthTable[i + 1]); i++)
            {
            }

            date -= _monthTable[i];
        }

        return i;
    }

    public static int GetDays(DateTime time)
    {
        int num = time.Year - 1900;
        int num2 = time.Month - 1;
        return _yearTable[num] + (IsLeapYear(time.Year) ? _monthLeapYearTable[num2] : _monthTable[num2]) + time.Day;
    }

    public static bool IsInYear(string period, DateTime time)
    {
        string[] array = period.Split('~');
        DateTime dateTime = ((array[0] == "*") ? DateTime.MinValue : XmlConvert.ToDateTime(array[0], XmlDateTimeSerializationMode.RoundtripKind));
        DateTime dateTime2 = ((array[1] == "*") ? DateTime.MaxValue : XmlConvert.ToDateTime(array[1], XmlDateTimeSerializationMode.RoundtripKind));
        return dateTime < time && time < dateTime2;
    }
}