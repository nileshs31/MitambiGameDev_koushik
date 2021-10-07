using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;
    private MeshRenderer meshRenderer;
    private string mainTex = "_MainTex";

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        scroll();
    }
    void scroll()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset(mainTex);
        offset.y += Time.deltaTime * speed;

        meshRenderer.sharedMaterial.SetTextureOffset(mainTex, offset);
    }
}
