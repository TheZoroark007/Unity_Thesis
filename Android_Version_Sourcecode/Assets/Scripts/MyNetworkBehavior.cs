using UnityEngine;
using Unity.Netcode;

// Attach this script to a GameObject with a NetworkObject component
public class MyNetworkedBehavior : NetworkBehaviour
{
    private float timeSinceLastUpdate = 0f;
    private float updateInterval = 1f / 23f; // update 23 times per second

    private void Update()
    {
        if(IsServer){
            timeSinceLastUpdate += Time.deltaTime;

        // check if enough time has passed since the last update
        if (timeSinceLastUpdate >= updateInterval)
        {
            // reset the timer
            timeSinceLastUpdate = 0f;

            // Call SendBytesServerRpc to send the byte array to the server
            SendBytesServerRpc(ImageData.serializedRenderTexture);
        }}
    }

    [ServerRpc]
    public void SendBytesServerRpc(byte[] byteArray)
    {
        // do something with the byte array on the server, if needed
        // then call the client RPC to send it to all clients
        SendBytesClientRpc(byteArray);
    }

    [ClientRpc]
    private void SendBytesClientRpc(byte[] byteArray)
    {
        // use byteArray here on the client
        Debug.Log("Received byte array with length " + byteArray.Length + " on client");
        ImageData.serializedRenderTexture = byteArray;
    }
}