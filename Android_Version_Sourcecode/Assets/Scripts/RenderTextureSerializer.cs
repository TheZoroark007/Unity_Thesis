using System.IO;
using UnityEngine;

public class RenderTextureSerializer : MonoBehaviour
{
    public RenderTexture inputTexture;
    public float updateRate = 1 / 23f;

    private float lastUpdateTime;

    private void Update()
    {
        if (Time.time - lastUpdateTime >= updateRate)
        {
            lastUpdateTime = Time.time;
            SerializeRenderTexture(inputTexture);
        }
    }

    public void SerializeRenderTexture(RenderTexture rt)
    {
        Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.RGBAFloat, false);
        RenderTexture.active = rt;
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        tex.Apply();
        RenderTexture.active = null;
        ImageData.serializedRenderTexture = tex.EncodeToJPG();
    }
}