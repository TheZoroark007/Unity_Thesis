using Unity.Netcode;
using UnityEngine;

public class RenderTextureNetworker : NetworkBehaviour
{
    public NetworkVariable<ByteArraySerializer> SerializedRenderTexture = new NetworkVariable<ByteArraySerializer>();

    void Update()
    {
    }
}


