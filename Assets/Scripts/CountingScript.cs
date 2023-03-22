using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class CountingScript : NetworkBehaviour
{ /*
    [SerializeField] private Text hostText;
    [SerializeField] private Text clientText;
    private int count = 0;
    private NetworkManager networkManager;

    private void Start()
    {
        networkManager = FindObjectOfType<NetworkManager>();
    }

  //  [ServerRpc]
    private void HostButtonPress()
    {
        count++;
        hostText.text = "Host: " + count.ToString();
    }

    [ClientRpc]
    private void ClientButtonPress()
    {
        count++;
        clientText.text = "Client: " + count.ToString();
    }

    private void Update()
    {
        if (!IsLocalPlayer)
        {
            return;
        }

        if (networkManager.IsServer && Input.GetKeyDown(KeyCode.Space))
        {
            HostButtonPress();
        }

        if (networkManager.IsClient && Input.GetKeyDown(KeyCode.Space))
        {
            ClientButtonPress();
        }
    }*/
}