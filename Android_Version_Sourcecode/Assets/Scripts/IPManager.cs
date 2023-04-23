using UnityEngine;

public class IPManager : MonoBehaviour
{   //Store IP Adress here for easy access
    public static string ipAddress;

    public void SetIpAddress(string ip)
    {
        ipAddress = ip;
    }
}