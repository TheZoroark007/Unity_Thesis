using System.Net;
using System;
using System.Text;
using System.Net.Sockets;
using UnityEngine;

public class SocketServer : MonoBehaviour
{
    private const int listenPort = 11000;
    private UdpClient listener;

    void Start()
    {
        listener = new UdpClient(listenPort);
        Debug.Log("Server started on port " + listenPort);

        // Send broadcast to all devices on network
        var broadcast = IPAddress.Parse("255.255.255.255");
        var data = Encoding.ASCII.GetBytes(GetLocalIPAddress());
        listener.EnableBroadcast = true;
        listener.Send(data, data.Length, new IPEndPoint(broadcast, listenPort));
    }

    void Update()
    {
        if (listener.Available > 0)
        {
            var remote = new IPEndPoint(IPAddress.Any, listenPort);
            var data = listener.Receive(ref remote);
            var message = Encoding.ASCII.GetString(data);
            Debug.Log("Message received: " + message);
        }
    }

    private string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("Local IP Address Not Found!");
    }
}

