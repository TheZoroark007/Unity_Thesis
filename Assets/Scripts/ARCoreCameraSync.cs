using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;
using UnityEngine.XR.ARFoundation;

public class ARCoreCameraSync : NetworkBehaviour
{
    [SerializeField] private Camera arCamera;

    // Called on the client
    void Update()
    {
        // Only execute on the client
        if (!IsLocalPlayer) return;

        // Get the ARCore camera position and rotation
        Vector3 position = arCamera.transform.position;
        Quaternion rotation = arCamera.transform.rotation;

        // Send the position and rotation to the server
        SyncCameraServerRpc(position, rotation);
    }

    // Called on the server
    [ServerRpc]
    void SyncCameraServerRpc(Vector3 position, Quaternion rotation)
    {
        // Rotate the host camera to match the ARCore camera
        // Only execute on the server
        if (!IsServer) return;

        Camera hostCamera = FindObjectOfType<Camera>();

        // Set the host camera's position and rotation to match the ARCore camera
        hostCamera.transform.position = position;
        hostCamera.transform.rotation = rotation;
    }
}
