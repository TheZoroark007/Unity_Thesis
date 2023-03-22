using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TCPReceiver : MonoBehaviour
{
    public int port = 8888;

    private TcpListener listener;

    private async void Start()
    {
        listener = new TcpListener(IPAddress.Any, port);
        listener.Start();

        Debug.Log("TCP server started on port " + port);

        try
        {
            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();

                Debug.Log("Client connected");

                StreamReader reader = new StreamReader(client.GetStream(), Encoding.ASCII);

                string message = await reader.ReadLineAsync();

                Debug.Log("Received message: " + message);

                // Do something with the message

                reader.Close();
                client.Close();
            }
        }
        catch (Exception e)
        {
            Debug.Log("Exception: " + e);
            listener.Stop();
        }
    }

    private void OnDestroy()
    {
        if (listener != null)
        {
            listener.Stop();
        }
    }
}
