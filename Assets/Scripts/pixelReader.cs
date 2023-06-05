using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pixelReader : MonoBehaviour
{
    /*
     * 挂在要监控的模型上即可
     */
    public Material material;
    public Texture texture;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;

    }

    // Update is called once per frame
    void Update()
    {
        texture = material.GetTexture("_MaskTexture");
        TextureToTexture2D(texture);
        
    }
    //返回该纹理有效像素的比例
    private float TextureToTexture2D(Texture texture)
    {
        Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 32);
        Graphics.Blit(texture, renderTexture);

        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        RenderTexture.active = currentRT;
        RenderTexture.ReleaseTemporary(renderTexture);
        Color[] pixels = texture2D.GetPixels();
        int width = texture2D.width;
        int height = texture2D.height;
        float nonTransparentPixelArea = 0;

        for (int i = 0; i < pixels.Length; i++)
        {
            if (pixels[i].a > 0)
            {
                nonTransparentPixelArea++;
            }
        }
        float percent = nonTransparentPixelArea / (height * width);
        Debug.Log(percent);
        return percent;
    }
}
