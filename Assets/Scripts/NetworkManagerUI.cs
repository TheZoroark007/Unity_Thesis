using System.Net;
using System;
using System.Text;
using System.Net.Sockets;
using System.Collections;
using UnityEngine;
using System.Net.NetworkInformation;
using UnityEngine.UI;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;


public class NetworkManagerUI : MonoBehaviour
{
 //   [SerializeField] private Button serverBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button changePerspectiveBtn;

    public GameObject changePerspectiveButton;
    public GameObject background;
    public GameObject qrCode;
    public GameObject kinect;
    public GameObject errorMessage;

    public GameObject waitingText;


    void Start()
    {
        // Send broadcast to all devices on network
        var broadcast = IPAddress.Parse("255.255.255.255");
        var data = Encoding.ASCII.GetBytes(GetLocalIPAddress());
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




private void Awake()
    {
        //Check if a client button exists
        if(clientBtn!= null) { 
        clientBtn.onClick.AddListener(() =>
        {
            string ipAddress = IPManager.ipAddress;
            //  NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes(ipAddress + ":7777");
            //For checking if connection succeeded
            NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnectCallback;
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(
              ipAddress, 
             (ushort)7777,
             ipAddress 
         );
            NetworkManager.Singleton.StartClient();
            Debug.Log("Connecting to " + ipAddress); 
            
        });
        }
        //Check if a host button exists
            if (hostBtn != null)
            {
                hostBtn.onClick.AddListener(() =>
                {
                    IPManager.ipAddress = GetLocalIPAddress();
                    string ipAddress = IPManager.ipAddress;

            //Enable QRCode generator here to parse the IP
            qrCode.SetActive(true);
            Debug.Log("Your IP is " + ipAddress);
            //For checking if connection succeeded
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectHandler;
            //Sets the Network Manager to the parameters of the host machine:
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(
                      ipAddress, 
                     (ushort)7777, 
                         ipAddress 
                 );
                    NetworkManager.Singleton.StartHost();
                });
            }
    }
    private void OnClientDisconnectCallback(ulong clientId)
    {
        //If no connection could be established after 5 seconds, display an error message
        Debug.Log("NetworkCallbackService OnClientDisconnectCallback: " + clientId);  
        errorMessage.SetActive(true);
        //Disable the waiting text displayed previously 
        waitingText.SetActive(false);
    }
    private void OnClientConnectHandler(ulong clientId)
    {
        //If a client connects to the host, enable the Azure Kinect Elements
        Debug.Log("NetworkCallbackService OnClientConnectCallback: " + clientId); 
        //Check if the connected client is the host itself
         if (clientId != NetworkManager.Singleton.LocalClientId)
    {
       // Debug.Log("Hello");
        changePerspectiveButton.SetActive(true);
        //Disable background and QR code and enable the Azure Kinect
         background.SetActive(false);
         qrCode.SetActive(false);
         kinect.SetActive(true);
    } 
        
        
    }

}
