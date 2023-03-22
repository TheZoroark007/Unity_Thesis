using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using UnityEngine;


public class SocketClient : MonoBehaviour
{
    private UdpClient udpClient;
    private IPEndPoint endPoint;
    private string ipAddress;
    private int port;

    private void Start()
    {
        // Initialize the UdpClient and set the endpoint
        udpClient = new UdpClient();
        udpClient.EnableBroadcast = true;

        // Set the IP address and port to the broadcast address and port 11000
      //  ipAddress = GetBroadcastAddress();
        ipAddress = "192.168.160.1";
        port = 11000;
        endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

        // Begin receiving messages
        udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), null);

        Debug.Log("Client started. Broadcasting to " + ipAddress + ":" + port);
    }

    private void OnDestroy()
    {
        // Close the UdpClient when the script is destroyed
        udpClient.Close();
    }

    private void ReceiveCallback(IAsyncResult ar)
    {
        // Get the received data and endpoint
        byte[] bytes = udpClient.EndReceive(ar, ref endPoint);
        string message = Encoding.UTF8.GetString(bytes);

        // Process the received message here
        Debug.Log("Received message from server: " + message);

        // Begin receiving messages again
        udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), null);
    }

    private string GetBroadcastAddress()
    {
        // Get the local IP address
        string hostName = Dns.GetHostName();
        IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
        IPAddress localIpAddress = null;
        foreach (IPAddress address in hostEntry.AddressList)
        {
            if (address.AddressFamily == AddressFamily.InterNetwork)
            {
                localIpAddress = address;
                break;
            }
        }

        if (localIpAddress == null)
        {
            throw new Exception("Failed to get local IP address.");
        }

        // Calculate the broadcast address from the subnet mask
        IPAddress subnetMask = IPAddress.Parse("255.255.255.0");
        byte[] ipAddressBytes = localIpAddress.GetAddressBytes();
        byte[] subnetMaskBytes = subnetMask.GetAddressBytes();
        byte[] broadcastAddressBytes = new byte[4];
        for (int i = 0; i < 4; i++)
        {
            broadcastAddressBytes[i] = (byte)(ipAddressBytes[i] | (subnetMaskBytes[i] ^ 255));
        }
        IPAddress broadcastAddress = new IPAddress(broadcastAddressBytes);

        return broadcastAddress.ToString();
    }
}
