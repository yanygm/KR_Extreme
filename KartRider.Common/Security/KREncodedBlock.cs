using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using KartRider.Common.Utilities;
using KartRider.IO;

namespace KartRider.Common.Security;

public class KREncodedBlock
{
    public enum EncodeFlag : byte
    {
        ZLib = 1,
        KartCrypto
    }

    public static byte[] Decode(byte[] inputBytes)
    {
        InPacket inPacket = new InPacket(inputBytes);
        if (inPacket.ReadByte() != 83)
        {
            return inputBytes;
        }

        EncodeFlag encodeFlag = (EncodeFlag)inPacket.ReadByte();
        uint num = inPacket.ReadUInt();
        uint key = (((encodeFlag & EncodeFlag.KartCrypto) != 0) ? inPacket.ReadUInt() : 0u);
        uint num2 = (((encodeFlag & EncodeFlag.ZLib) != 0) ? inPacket.ReadUInt() : 0u);
        byte[] array = inPacket.ReadBytes(inPacket.Available);
        if ((encodeFlag & EncodeFlag.KartCrypto) != 0)
        {
            array = KRCrypto.ApplyCrypto(array, key);
        }

        if ((encodeFlag & EncodeFlag.ZLib) != 0)
        {
            if (array[0] != 120 && array[1] != 218)
            {
                throw new Exception("Invalid magic header! (zlib)");
            }

            int host = BitConverter.ToInt32(array, array.Length - 4);
            byte[] array2 = new byte[array.Length - 2];
            Buffer.BlockCopy(array, 2, array2, 0, array2.Length);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using MemoryStream stream = new MemoryStream(array2);
                using DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress);
                deflateStream.CopyTo(memoryStream);
                deflateStream.Close();
                array = memoryStream.ToArray();
            }

            if (num2 != array.Length)
            {
                throw new Exception("Length was not equal");
            }

            int num3 = Adler32Helper.GenerateSimpleAdler32(array);
            if (num3 != IPAddress.HostToNetworkOrder(host))
            {
                throw new Exception("Invalid checksum!");
            }
        }

        if (Adler32Helper.GenerateAdler32(array) != num)
        {
            throw new Exception("Checksums didnt match.");
        }

        if ((encodeFlag & EncodeFlag.ZLib) != 0 && num2 != array.Length)
        {
            throw new Exception("Lengths did not match");
        }

        return array;
    }

    public static byte[] Encode(byte[] inputBytes, EncodeFlag flag, uint? kartCryptoKey)
    {
        using OutPacket outPacket = new OutPacket();
        outPacket.WriteByte(83);
        outPacket.WriteByte((byte)flag);
        outPacket.WriteUInt(Adler32Helper.GenerateAdler32(inputBytes));
        if ((flag & EncodeFlag.KartCrypto) != 0)
        {
            if (!kartCryptoKey.HasValue)
            {
                kartCryptoKey = Adler32Helper.GenerateAdler32(inputBytes);
            }

            outPacket.WriteUInt(kartCryptoKey.Value);
        }

        if ((flag & EncodeFlag.ZLib) != 0)
        {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            using MemoryStream memoryStream2 = new MemoryStream();
            using DeflateStream deflateStream = new DeflateStream(memoryStream2, CompressionMode.Compress);
            using (MemoryStream memoryStream3 = new MemoryStream(inputBytes))
            {
                memoryStream3.CopyTo(deflateStream);
            }

            deflateStream.Close();
            outPacket.WriteInt(inputBytes.Length);
            byte[] buffer = memoryStream2.ToArray();
            binaryWriter.Write(new byte[2] { 120, 218 });
            binaryWriter.Write(buffer);
            binaryWriter.Write(IPAddress.HostToNetworkOrder(Adler32Helper.GenerateSimpleAdler32(inputBytes)));
            inputBytes = memoryStream.ToArray();
        }

        if ((flag & EncodeFlag.KartCrypto) != 0)
        {
            inputBytes = KRCrypto.ApplyCrypto(inputBytes, kartCryptoKey.Value);
        }

        outPacket.WriteBytes(inputBytes);
        return outPacket.ToArray();
    }
}