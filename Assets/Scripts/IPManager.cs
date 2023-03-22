using UnityEngine;

public class IPManager : MonoBehaviour
{
    public static string ipAddress;

    public void SetIpAddress(string ip)
    {
        ipAddress = ip;
    }
}