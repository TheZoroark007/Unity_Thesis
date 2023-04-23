using UnityEngine;

public class RotationVariable : MonoBehaviour
{
    public static Quaternion cameraRotation = Quaternion.identity;

    private void Update()
    {
        cameraRotation = transform.rotation;
    }
}