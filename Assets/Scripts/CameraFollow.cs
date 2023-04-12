using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public bool applyZOffset = true;

    private Quaternion initialRotation;

    public Button toggleZOffsetButton;

    // Reference to the RotationVariable script
    public RotationVariable rotationVariableScript;

    private void Start()
    {
        // Get the rotation from the static variable in the RotationVariable script
       initialRotation = RotationVariable.cameraRotation;

        // Add an onClick listener to the button to toggle the Z offset option
        if (toggleZOffsetButton != null)
        {
            toggleZOffsetButton.onClick.AddListener(ToggleZOffset);
        }
    }

    private void LateUpdate()
    {
        if (targetObject != null)
        {
            Vector3 newPosition = targetObject.position;
            if (applyZOffset)
            {
                newPosition -= Vector3.forward * 0.5f;
            }
            transform.position = newPosition;

            // Set the rotation from the static variable in the RotationVariable script
            transform.rotation = RotationVariable.cameraRotation;
        }
    }

    private void ToggleZOffset()
    {
        applyZOffset = !applyZOffset;
    }
}











