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

            using (OutPacket outPacket = new OutPacket())
            {
                outPacket.WriteBytes(iPacket.ToArray());
                Parent.Server.Send(outPacket);
            }
        }
    }
}
