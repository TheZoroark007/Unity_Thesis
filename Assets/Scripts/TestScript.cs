using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class TestScript : MonoBehaviour

{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SendBytesServerRpc(ImageData.serializedRenderTexture);
    }
    [ServerRpc]
    public void SendBytesServerRpc(byte[] myArr)
    {
        //  SendBytesClientRpc(myArr);
        Debug.Log("Hello");
    } //SendBytesServerRpc

    [ClientRpc]
    private void SendBytesClientRpc(byte[] myArr)
    {
        //use myArr here
        ImageData.serializedRenderTexture = myArr;
        Debug.Log(myArr);
    } //SendBytesClientRpc
}
