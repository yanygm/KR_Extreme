using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using KartRider;
using KartRider.Common.Network;
using KartRider.Common.Utilities;
using KartRider.Data;
using KartRider.IO;
using KartRider.TrackName;

namespace Extreme;

public class ClientSession : Session
{
    public SessionGroup Parent { get; set; }

    public CheckState Unchecked { get; private set; }

    public ClientSession(SessionGroup parent, Socket socket) : base(socket)
    {
        Parent = parent;
    }

    public override void OnDisconnect()
    {
        Console.WriteLine("Client_Disconnected");
        Parent.Server.Disconnect();
        ((Session)Parent.Client).Disconnect();
    }

    public override void OnPacket(InPacket iPacket)
    {
        lock (Parent.m_lock)
        {
            iPacket.Position = 0;
            uint num = iPacket.ReadUInt();
            PacketName packetName = (PacketName)num;
            Console.WriteLine("Send-{0}: {1}", packetName, BitConverter.ToString(iPacket.ToArray()).Replace("-", " "));
            if (num == Adler32Helper.GenerateAdler32_ASCII("ChClientUdpAddrPacket", 0))
            {
                Parent.UDPAddr.RelayedEndPoint = iPacket.ReadEndPoint();
                Console.WriteLine($"ChClientUdpAddrPacket : {Parent.UDPAddr.RelayedEndPoint.Address}:{Parent.UDPAddr.RelayedEndPoint.Port}, Local : {Parent.UDPAddr.SocketEndPoint.Address}:{Parent.UDPAddr.SocketEndPoint.Port}");
                Default(iPacket);
            }
            else if (num == Adler32Helper.GenerateAdler32_ASCII("ChClientP2pAddrPacket", 0))
            {
                Parent.P2PAddr.RelayedEndPoint = iPacket.ReadEndPoint();
                Console.WriteLine($"ChClientP2pAddrPacket : {Parent.P2PAddr.RelayedEndPoint.Address}:{Parent.P2PAddr.RelayedEndPoint.Port}, Local : {Parent.P2PAddr.SocketEndPoint.Address}:{Parent.P2PAddr.SocketEndPoint.Port}");
                Default(iPacket);
            }
            else
            {
                Default(iPacket);
            }
        }
    }

    public void Default(InPacket iPacket)
    {
        using (OutPacket outPacket = new OutPacket())
        {
            outPacket.WriteBytes(iPacket.ToArray());
            Parent.Server.Send(outPacket);
        }
    }
}
