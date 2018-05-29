using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CamScript : MonoBehaviour
{
    Camera cam;
    public float intensity;
    private Material imageEffect;

    // Creates a private material used to the effect
    void Awake()
    {
        imageEffect = new Material(Shader.Find("Hidden/Monochrome"));
        cam = this.GetComponent<Camera>();
    }

    // Postprocess the image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (intensity == 0)
        {
            Graphics.Blit(source, destination);
            return;
        }
        imageEffect.SetFloat("_bwBlend", intensity);
        Graphics.Blit(source, destination, imageEffect);
    }
}
