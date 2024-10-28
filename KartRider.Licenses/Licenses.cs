using System;
using System.Threading;
using Extreme;
using KartRider.Common.Security;
using KartRider.IO;

namespace KartRider.Licenses;

public static class Licenses
{
	public static void Licenses_Clear()
	{
		new Thread((ThreadStart)delegate
		{
			OutPacket val = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val2 = new OutPacket(4);
				val2.WriteTime(DateTime.Now);
				byte[] array = KREncodedBlock.Encode(((PacketBase)val2).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val.WriteInt(array.Length);
				val.WriteBytes(array);
				val.WriteInt(2233);
				val.WriteByte((byte)1);
				val.WriteInt(15000);
				RouterListener.MySession.Server.Send(val);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val3 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val4 = new OutPacket(4);
				val4.WriteTime(DateTime.Now);
				byte[] array2 = KREncodedBlock.Encode(((PacketBase)val4).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val3.WriteInt(array2.Length);
				val3.WriteBytes(array2);
				val3.WriteInt(22732);
				val3.WriteByte((byte)2);
				val3.WriteInt(7000);
				RouterListener.MySession.Server.Send(val3);
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val5 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val6 = new OutPacket(4);
				val6.WriteTime(DateTime.Now);
				byte[] array3 = KREncodedBlock.Encode(((PacketBase)val6).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val5.WriteInt(array3.Length);
				val5.WriteBytes(array3);
				val5.WriteInt(13978);
				val5.WriteByte((byte)3);
				val5.WriteInt(12000);
				RouterListener.MySession.Server.Send(val5);
			}
			finally
			{
				((IDisposable)val5)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val7 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val8 = new OutPacket(4);
				val8.WriteTime(DateTime.Now);
				byte[] array4 = KREncodedBlock.Encode(((PacketBase)val8).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val7.WriteInt(array4.Length);
				val7.WriteBytes(array4);
				val7.WriteInt(13979);
				val7.WriteByte((byte)4);
				val7.WriteInt(30000);
				RouterListener.MySession.Server.Send(val7);
			}
			finally
			{
				((IDisposable)val7)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val9 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val10 = new OutPacket(4);
				val10.WriteTime(DateTime.Now);
				byte[] array5 = KREncodedBlock.Encode(((PacketBase)val10).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val9.WriteInt(array5.Length);
				val9.WriteBytes(array5);
				val9.WriteInt(1643);
				val9.WriteByte((byte)5);
				val9.WriteInt(4700);
				RouterListener.MySession.Server.Send(val9);
			}
			finally
			{
				((IDisposable)val9)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val11 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val12 = new OutPacket(4);
				val12.WriteTime(DateTime.Now);
				byte[] array6 = KREncodedBlock.Encode(((PacketBase)val12).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val11.WriteInt(array6.Length);
				val11.WriteBytes(array6);
				val11.WriteInt(20414);
				val11.WriteByte((byte)6);
				val11.WriteInt(24000);
				RouterListener.MySession.Server.Send(val11);
			}
			finally
			{
				((IDisposable)val11)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val13 = new OutPacket("PqUpdateRiderSchoolLevelPacket");
			try
			{
				val13.WriteByte((byte)1);
				RouterListener.MySession.Server.Send(val13);
			}
			finally
			{
				((IDisposable)val13)?.Dispose();
			}
			Thread.Sleep(1000);
			OutPacket val14 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val15 = new OutPacket(4);
				val15.WriteTime(DateTime.Now);
				byte[] array7 = KREncodedBlock.Encode(((PacketBase)val15).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val14.WriteInt(array7.Length);
				val14.WriteBytes(array7);
				val14.WriteInt(23462);
				val14.WriteByte((byte)7);
				val14.WriteInt(17000);
				RouterListener.MySession.Server.Send(val14);
			}
			finally
			{
				((IDisposable)val14)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val16 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val17 = new OutPacket(4);
				val17.WriteTime(DateTime.Now);
				byte[] array8 = KREncodedBlock.Encode(((PacketBase)val17).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val16.WriteInt(array8.Length);
				val16.WriteBytes(array8);
				val16.WriteInt(171);
				val16.WriteByte((byte)8);
				val16.WriteInt(4600);
				RouterListener.MySession.Server.Send(val16);
			}
			finally
			{
				((IDisposable)val16)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val18 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val19 = new OutPacket(4);
				val19.WriteTime(DateTime.Now);
				byte[] array9 = KREncodedBlock.Encode(((PacketBase)val19).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val18.WriteInt(array9.Length);
				val18.WriteBytes(array9);
				val18.WriteInt(14140);
				val18.WriteByte((byte)9);
				val18.WriteInt(8000);
				RouterListener.MySession.Server.Send(val18);
			}
			finally
			{
				((IDisposable)val18)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val20 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val21 = new OutPacket(4);
				val21.WriteTime(DateTime.Now);
				byte[] array10 = KREncodedBlock.Encode(((PacketBase)val21).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val20.WriteInt(array10.Length);
				val20.WriteBytes(array10);
				val20.WriteInt(21895);
				val20.WriteByte((byte)10);
				val20.WriteInt(18000);
				RouterListener.MySession.Server.Send(val20);
			}
			finally
			{
				((IDisposable)val20)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val22 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val23 = new OutPacket(4);
				val23.WriteTime(DateTime.Now);
				byte[] array11 = KREncodedBlock.Encode(((PacketBase)val23).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val22.WriteInt(array11.Length);
				val22.WriteBytes(array11);
				val22.WriteInt(14997);
				val22.WriteByte((byte)11);
				val22.WriteInt(8000);
				RouterListener.MySession.Server.Send(val22);
			}
			finally
			{
				((IDisposable)val22)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val24 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val25 = new OutPacket(4);
				val25.WriteTime(DateTime.Now);
				byte[] array12 = KREncodedBlock.Encode(((PacketBase)val25).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val24.WriteInt(array12.Length);
				val24.WriteBytes(array12);
				val24.WriteInt(20377);
				val24.WriteByte((byte)12);
				val24.WriteInt(106000);
				RouterListener.MySession.Server.Send(val24);
			}
			finally
			{
				((IDisposable)val24)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val26 = new OutPacket("PqUpdateRiderSchoolLevelPacket");
			try
			{
				val26.WriteByte((byte)2);
				RouterListener.MySession.Server.Send(val26);
			}
			finally
			{
				((IDisposable)val26)?.Dispose();
			}
			Thread.Sleep(1000);
			OutPacket val27 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val28 = new OutPacket(4);
				val28.WriteTime(DateTime.Now);
				byte[] array13 = KREncodedBlock.Encode(((PacketBase)val28).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val27.WriteInt(array13.Length);
				val27.WriteBytes(array13);
				val27.WriteInt(15092);
				val27.WriteByte((byte)13);
				val27.WriteInt(13900);
				RouterListener.MySession.Server.Send(val27);
			}
			finally
			{
				((IDisposable)val27)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val29 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val30 = new OutPacket(4);
				val30.WriteTime(DateTime.Now);
				byte[] array14 = KREncodedBlock.Encode(((PacketBase)val30).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val29.WriteInt(array14.Length);
				val29.WriteBytes(array14);
				val29.WriteInt(17207);
				val29.WriteByte((byte)14);
				val29.WriteInt(12000);
				RouterListener.MySession.Server.Send(val29);
			}
			finally
			{
				((IDisposable)val29)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val31 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val32 = new OutPacket(4);
				val32.WriteTime(DateTime.Now);
				byte[] array15 = KREncodedBlock.Encode(((PacketBase)val32).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val31.WriteInt(array15.Length);
				val31.WriteBytes(array15);
				val31.WriteInt(3754);
				val31.WriteByte((byte)15);
				val31.WriteInt(20000);
				RouterListener.MySession.Server.Send(val31);
			}
			finally
			{
				((IDisposable)val31)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val33 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val34 = new OutPacket(4);
				val34.WriteTime(DateTime.Now);
				byte[] array16 = KREncodedBlock.Encode(((PacketBase)val34).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val33.WriteInt(array16.Length);
				val33.WriteBytes(array16);
				val33.WriteInt(1641);
				val33.WriteByte((byte)16);
				val33.WriteInt(13750);
				RouterListener.MySession.Server.Send(val33);
			}
			finally
			{
				((IDisposable)val33)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val35 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val36 = new OutPacket(4);
				val36.WriteTime(DateTime.Now);
				byte[] array17 = KREncodedBlock.Encode(((PacketBase)val36).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val35.WriteInt(array17.Length);
				val35.WriteBytes(array17);
				val35.WriteInt(56);
				val35.WriteByte((byte)17);
				val35.WriteInt(18750);
				RouterListener.MySession.Server.Send(val35);
			}
			finally
			{
				((IDisposable)val35)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val37 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val38 = new OutPacket(4);
				val38.WriteTime(DateTime.Now);
				byte[] array18 = KREncodedBlock.Encode(((PacketBase)val38).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val37.WriteInt(array18.Length);
				val37.WriteBytes(array18);
				val37.WriteInt(13670);
				val37.WriteByte((byte)18);
				val37.WriteInt(118500);
				RouterListener.MySession.Server.Send(val37);
			}
			finally
			{
				((IDisposable)val37)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val39 = new OutPacket("PqUpdateRiderSchoolLevelPacket");
			try
			{
				val39.WriteByte((byte)3);
				RouterListener.MySession.Server.Send(val39);
			}
			finally
			{
				((IDisposable)val39)?.Dispose();
			}
			Thread.Sleep(1000);
			OutPacket val40 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val41 = new OutPacket(4);
				val41.WriteTime(DateTime.Now);
				byte[] array19 = KREncodedBlock.Encode(((PacketBase)val41).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val40.WriteInt(array19.Length);
				val40.WriteBytes(array19);
				val40.WriteInt(10364);
				val40.WriteByte((byte)19);
				val40.WriteInt(4500);
				RouterListener.MySession.Server.Send(val40);
			}
			finally
			{
				((IDisposable)val40)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val42 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val43 = new OutPacket(4);
				val43.WriteTime(DateTime.Now);
				byte[] array20 = KREncodedBlock.Encode(((PacketBase)val43).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val42.WriteInt(array20.Length);
				val42.WriteBytes(array20);
				val42.WriteInt(10364);
				val42.WriteByte((byte)20);
				val42.WriteInt(23500);
				RouterListener.MySession.Server.Send(val42);
			}
			finally
			{
				((IDisposable)val42)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val44 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val45 = new OutPacket(4);
				val45.WriteTime(DateTime.Now);
				byte[] array21 = KREncodedBlock.Encode(((PacketBase)val45).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val44.WriteInt(array21.Length);
				val44.WriteBytes(array21);
				val44.WriteInt(10364);
				val44.WriteByte((byte)21);
				val44.WriteInt(140000);
				RouterListener.MySession.Server.Send(val44);
			}
			finally
			{
				((IDisposable)val44)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val46 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val47 = new OutPacket(4);
				val47.WriteTime(DateTime.Now);
				byte[] array22 = KREncodedBlock.Encode(((PacketBase)val47).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val46.WriteInt(array22.Length);
				val46.WriteBytes(array22);
				val46.WriteInt(10364);
				val46.WriteByte((byte)22);
				val46.WriteInt(47500);
				RouterListener.MySession.Server.Send(val46);
			}
			finally
			{
				((IDisposable)val46)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val48 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val49 = new OutPacket(4);
				val49.WriteTime(DateTime.Now);
				byte[] array23 = KREncodedBlock.Encode(((PacketBase)val49).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val48.WriteInt(array23.Length);
				val48.WriteBytes(array23);
				val48.WriteInt(10364);
				val48.WriteByte((byte)23);
				val48.WriteInt(140000);
				RouterListener.MySession.Server.Send(val48);
			}
			finally
			{
				((IDisposable)val48)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val50 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val51 = new OutPacket(4);
				val51.WriteTime(DateTime.Now);
				byte[] array24 = KREncodedBlock.Encode(((PacketBase)val51).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val50.WriteInt(array24.Length);
				val50.WriteBytes(array24);
				val50.WriteInt(10364);
				val50.WriteByte((byte)24);
				val50.WriteInt(122000);
				RouterListener.MySession.Server.Send(val50);
			}
			finally
			{
				((IDisposable)val50)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val52 = new OutPacket("PqUpdateRiderSchoolLevelPacket");
			try
			{
				val52.WriteByte((byte)4);
				RouterListener.MySession.Server.Send(val52);
			}
			finally
			{
				((IDisposable)val52)?.Dispose();
			}
			Thread.Sleep(1000);
			OutPacket val53 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val54 = new OutPacket(4);
				val54.WriteTime(DateTime.Now);
				byte[] array25 = KREncodedBlock.Encode(((PacketBase)val54).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val53.WriteInt(array25.Length);
				val53.WriteBytes(array25);
				val53.WriteInt(10333);
				val53.WriteByte((byte)25);
				val53.WriteInt(39500);
				RouterListener.MySession.Server.Send(val53);
			}
			finally
			{
				((IDisposable)val53)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val55 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val56 = new OutPacket(4);
				val56.WriteTime(DateTime.Now);
				byte[] array26 = KREncodedBlock.Encode(((PacketBase)val56).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val55.WriteInt(array26.Length);
				val55.WriteBytes(array26);
				val55.WriteInt(10333);
				val55.WriteByte((byte)26);
				val55.WriteInt(40500);
				RouterListener.MySession.Server.Send(val55);
			}
			finally
			{
				((IDisposable)val55)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val57 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val58 = new OutPacket(4);
				val58.WriteTime(DateTime.Now);
				byte[] array27 = KREncodedBlock.Encode(((PacketBase)val58).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val57.WriteInt(array27.Length);
				val57.WriteBytes(array27);
				val57.WriteInt(10333);
				val57.WriteByte((byte)27);
				val57.WriteInt(29250);
				RouterListener.MySession.Server.Send(val57);
			}
			finally
			{
				((IDisposable)val57)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val59 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val60 = new OutPacket(4);
				val60.WriteTime(DateTime.Now);
				byte[] array28 = KREncodedBlock.Encode(((PacketBase)val60).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val59.WriteInt(array28.Length);
				val59.WriteBytes(array28);
				val59.WriteInt(10333);
				val59.WriteByte((byte)28);
				val59.WriteInt(43500);
				RouterListener.MySession.Server.Send(val59);
			}
			finally
			{
				((IDisposable)val59)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val61 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val62 = new OutPacket(4);
				val62.WriteTime(DateTime.Now);
				byte[] array29 = KREncodedBlock.Encode(((PacketBase)val62).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val61.WriteInt(array29.Length);
				val61.WriteBytes(array29);
				val61.WriteInt(10333);
				val61.WriteByte((byte)29);
				val61.WriteInt(150000);
				RouterListener.MySession.Server.Send(val61);
			}
			finally
			{
				((IDisposable)val61)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val63 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val64 = new OutPacket(4);
				val64.WriteTime(DateTime.Now);
				byte[] array30 = KREncodedBlock.Encode(((PacketBase)val64).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val63.WriteInt(array30.Length);
				val63.WriteBytes(array30);
				val63.WriteInt(10333);
				val63.WriteByte((byte)30);
				val63.WriteInt(114250);
				RouterListener.MySession.Server.Send(val63);
			}
			finally
			{
				((IDisposable)val63)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val65 = new OutPacket("PqUpdateRiderSchoolLevelPacket");
			try
			{
				val65.WriteByte((byte)5);
				RouterListener.MySession.Server.Send(val65);
			}
			finally
			{
				((IDisposable)val65)?.Dispose();
			}
			Thread.Sleep(1000);
			OutPacket val66 = new OutPacket("PqRewardProEmblemPacket");
			try
			{
				val66.WriteShort((short)8524);
				RouterListener.MySession.Server.Send(val66);
			}
			finally
			{
				((IDisposable)val66)?.Dispose();
			}
			Thread.Sleep(1000);
			OutPacket val67 = new OutPacket("PqRiderSchoolProPacket");
			try
			{
				RouterListener.MySession.Server.Send(val67);
			}
			finally
			{
				((IDisposable)val67)?.Dispose();
			}
			Thread.Sleep(3000);
			OutPacket val68 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val69 = new OutPacket(4);
				val69.WriteTime(DateTime.Now);
				byte[] array31 = KREncodedBlock.Encode(((PacketBase)val69).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val68.WriteInt(array31.Length);
				val68.WriteBytes(array31);
				val68.WriteInt(10343);
				val68.WriteByte((byte)35);
				val68.WriteInt(114850);
				RouterListener.MySession.Server.Send(val68);
			}
			finally
			{
				((IDisposable)val68)?.Dispose();
			}
			OutPacket val70 = new OutPacket("LoRqUpdateRiderSchoolDataPacket");
			try
			{
				OutPacket val71 = new OutPacket(4);
				val71.WriteTime(DateTime.Now);
				byte[] array32 = KREncodedBlock.Encode(((PacketBase)val71).ToArray(), (KREncodedBlock.EncodeFlag)2, (uint?)2242368262u);
				val70.WriteInt(array32.Length);
				val70.WriteBytes(array32);
				val70.WriteInt(10343);
				val70.WriteByte((byte)36);
				val70.WriteInt(140000);
				RouterListener.MySession.Server.Send(val70);
			}
			finally
			{
				((IDisposable)val70)?.Dispose();
			}
			Thread.Sleep(200);
			OutPacket val72 = new OutPacket("PqUpdateRiderSchoolLevelPacket");
			try
			{
				val72.WriteByte((byte)6);
				RouterListener.MySession.Server.Send(val72);
			}
			finally
			{
				((IDisposable)val72)?.Dispose();
			}
		}).Start();
	}
}
