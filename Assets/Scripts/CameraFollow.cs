using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public bool applyZOffset = true;

    private Quaternion initialRotation;

    public Button toggleZOffsetButton;

    private void Start()
    {
        initialRotation = transform.rotation;

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
            transform.rotation = initialRotation;
        }
    }

    // Toggle the applyZOffset option when the button is clicked
    private void ToggleZOffset()
    {
        applyZOffset = !applyZOffset;
    }
}










