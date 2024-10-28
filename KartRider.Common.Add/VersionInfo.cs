using System;

namespace KartRider.Common.Add;

public class VersionInfo
{
	public static string GetLang(byte nLang)
	{
		switch (nLang)
		{
		case 118:
			return "kr";
		case 219:
			return "tw";
		case 47:
			return "cn";
		default:
			Console.WriteLine("UNKNOWN LANG {0}", nLang);
			return "unk";
		}
	}

	public static string GetRegionFromLocale(ushort usLocale)
	{
		switch (usLocale)
		{
		case 1002:
			return "KOR(OFFICIAL)";
		case 4002:
			return "TAI(OFFICIAL)";
		case 3002:
			return "CHI(OFFICIAL)";
		default:
			Console.WriteLine("UNKNOWN LOCALE {0}", usLocale);
			return "UNK";
		}
	}
}
