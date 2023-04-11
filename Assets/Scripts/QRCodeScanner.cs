using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using ZXing;
using ZXing.QrCode;

public class QRCodeScanner : MonoBehaviour
{
    public GameObject arCoreGameObject;
    private WebCamTexture camTexture;
    private Rect screenRect;
    private bool isScanning = false;

    void Start()
    {
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
    }

    void Update()
    {
        if (isScanning && camTexture.isPlaying)
        {
            // Get the camera frame
            Color32[] pixels = new Color32[camTexture.width * camTexture.height];
            camTexture.GetPixels32(pixels);

            // Decode the QR code
            var barcodeReader = new BarcodeReader();
            var result = barcodeReader.Decode(pixels, camTexture.width, camTexture.height);

            if (result != null)
            {
                Debug.Log("Scanned QR code: " + result.Text);
                // Set the IP address in the IPManager script
                IPManager ipManager = FindObjectOfType<IPManager>();
                if (ipManager != null)
                {
                    ipManager.SetIpAddress(result.Text);
                    Debug.Log("Ip Adress recognized as" + IPManager.ipAddress);
                }
                isScanning = false;
                camTexture.Stop();

                // Load the ARCore scene and enable the ARCore functionality
                SceneManager.LoadScene("ARCoreScene");
            }
        }
    }

    public void ScanQRCode()
    {
        isScanning = true;
        camTexture = new WebCamTexture();
        camTexture.Play();
    }

    public void LoadARCoreScene()
    {
        SceneManager.LoadScene("ARCoreScene");
    }

    void OnGUI()
    {
        // Check if the camera texture has been set
        if (camTexture == null)
        {
            return;
        }

        // Calculate the camera texture's aspect ratio
        float cameraAspectRatio = (float)camTexture.width / (float)camTexture.height;

        // Calculate the size and position of the camera texture
        float height = Screen.height;
        float width = height * cameraAspectRatio;
        float left = (Screen.width - width) / 2;
        float top = (Screen.height - height) / 2;

        // Create a new Rect object for the camera texture
        Rect cameraRect = new Rect(left, top, width, height);

        // If the device is in portrait mode, rotate the camera texture by 90 degrees and adjust the cameraRect
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            GUIUtility.RotateAroundPivot(90, new Vector2(left + (width / 2), top + (height / 2)));
            cameraRect = new Rect((Screen.width - height) / 2, (Screen.height - width) / 2, height, width);
        }

        // Draw the camera texture on the screen
        GUI.DrawTexture(cameraRect, camTexture, ScaleMode.ScaleToFit);

    }
    }
