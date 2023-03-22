using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TCPServer : MonoBehaviour
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

                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                Debug.Log("Received message: " + message);

                // Do something with the message

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
