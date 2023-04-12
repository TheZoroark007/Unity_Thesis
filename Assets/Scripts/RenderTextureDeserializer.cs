using UnityEngine;


public class RenderTextureDeserializer : MonoBehaviour
{
    public RenderTexture outputTexture;
    public float updateRate = 1 / 23f;

    private float lastUpdateTime;

    void Start()
    {
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(ImageData.serializedRenderTexture);
        outputTexture.Release();
        outputTexture.Create();
        Graphics.Blit(tex, outputTexture);
        lastUpdateTime = Time.time;
    }

    void Update()
    {
        if (Time.time - lastUpdateTime >= updateRate)
        {
            lastUpdateTime = Time.time;
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(ImageData.serializedRenderTexture);
            outputTexture.Release();
            outputTexture.Create();
            Graphics.Blit(tex, outputTexture);
        }
    }
}

