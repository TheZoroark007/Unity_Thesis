using Unity.Netcode;
using UnityEngine;

public class CameraSpawn : NetworkBehaviour
{
    public GameObject cameraPrefab;
    private NetworkObject spawnedCamera;

    void Start()
    {
        if (IsServer)
        {
            spawnedCamera = Instantiate(cameraPrefab).GetComponent<NetworkObject>();
            spawnedCamera.Spawn();
        }
    }

    public override void OnNetworkSpawn()
    {
        if (IsClient)
        {
            spawnedCamera = Instantiate(cameraPrefab).GetComponent<NetworkObject>();
            spawnedCamera.Spawn();
        }
    }
}
