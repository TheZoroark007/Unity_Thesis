using UnityEngine;
using UnityEngine.SceneManagement;

public class ForceARMode : MonoBehaviour
{
    // Other QR code scanning code goes here...

    public void LoadARCoreScene()
    {
        SceneManager.LoadScene("ARCoreScene");
    }
}