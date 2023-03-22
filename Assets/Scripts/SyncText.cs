using UnityEngine;
using TMPro;
using Unity.Netcode;

public class SyncText : NetworkBehaviour
{
    [SerializeField]
    private NetworkVariable<int> m_CountValue = new NetworkVariable<int>(1);

    [SerializeField]
    private TextMeshProUGUI m_TextElement;

    private void Update()
    {
        if (IsClient && IsOwner)
        {
            // Handle input on the owner client only
            HandleInput();
        }

        if (IsClient && !IsOwner)
        {
            // Update the text element on all clients except the owner
            m_TextElement.text = m_CountValue.Value.ToString();
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Increment the count value when the space key is pressed
            m_CountValue.Value++;
        }
    }
}
