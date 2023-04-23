using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using System.Net.Sockets;
using System.Net.NetworkInformation;

public class QRCodeGenerator : MonoBehaviour
{
    private string codeText;
    public int size;

    void Start()
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = size,
                Width = size
            }
        };
        //Set the IP adress to the aIP of the host
        string ipAddress = IPManager.ipAddress;
        codeText = ipAddress;
        //Encode text to QR
        var encoded = writer.Encode(codeText);
        var texture = new Texture2D(encoded.Width, encoded.Height);
        for (int y = 0; y < encoded.Height; ++y)
        {
            for (int x = 0; x < encoded.Width; ++x)
            {
                texture.SetPixel(x, y, encoded[x, y] ? Color.black : Color.white);
            }
        }
        texture.Apply();
        GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        GetComponent<RectTransform>().sizeDelta = new Vector2(texture.width, texture.height);
    }
}


