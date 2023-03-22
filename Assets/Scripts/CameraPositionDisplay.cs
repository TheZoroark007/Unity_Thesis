using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;
using TMPro;

public class CameraPositionDisplay : MonoBehaviour
{
    public TextMeshProUGUI positionText;
    public TextMeshProUGUI rotationText;

    void Update()
    {   //Change text if this script is executed on the client (Smartphone)
        //Maybe change so it reads and writes from a file with static value
        if (NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer && !NetworkManager.Singleton.IsHost)
        {
            // Get the camera position and rotation
            Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        // Update the TextMeshPro text
        
        
        positionText.SetText("Position: " + position.ToString());
        rotationText.SetText("Rotation: " + rotation.eulerAngles.ToString());
        }

        else
        {
        }
    }
}
