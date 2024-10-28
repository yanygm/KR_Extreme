using System;
using System.Net;
using System.Net.Sockets;

namespace Extreme;

public class RouterListener
{
	public static string sIP;

	public static string forceConnect;

	public static IPEndPoint CurrentUDPServer { get; set; }

	public static string ForceConnect { get; set; }

	public static TcpListener Listener { get; private set; }

	public static SessionGroup MySession { get; set; }

	public static bool NewConnRequest { get; set; }

	static RouterListener()
	{
		string text = "162.14.144.161";
		sIP = text;
	}

	public static void OnAcceptSocket(IAsyncResult ar)
	{
		try
		{
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			Socket clientSocket = Listener.EndAcceptSocket(ar);
			forceConnect = sIP;
			if (!(ForceConnect == "") && ForceConnect != "0.0.0.0")
			{
				forceConnect = ForceConnect;
			}
			Console.WriteLine("Connecting to {0}:39311", forceConnect);
			socket.Connect(forceConnect, 39311);
			if (socket.Connected)
			{
				MySession = new SessionGroup(clientSocket, socket);
			}
			NewConnRequest = false;
		}
		catch
		{
		}
		Listener.BeginAcceptSocket(OnAcceptSocket, null);
	}

	public static void Start()
	{
		Console.WriteLine("Starting RouterListener...");
		ForceConnect = "";
		NewConnRequest = false;
		Listener = new TcpListener(IPAddress.Any, 39312);
		Listener.Start();
		Listener.BeginAcceptSocket(OnAcceptSocket, null);
		Console.WriteLine("RouterListener Listeneing on Port 39312!");
		CurrentUDPServer = new IPEndPoint(IPAddress.Parse(sIP), 39311);
	}
}
