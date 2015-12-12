using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour
{
    public float size = 1;

    private MeshRenderer mr;
    private Vector2 originalScale;

    private void Start()
    {
        mr.sharedMaterial.mainTextureScale = Vector2.one * 256;
        mr = GetComponentInChildren<MeshRenderer>();
        originalScale = mr.sharedMaterial.mainTextureScale;
    }

    private void Update()
    {
        transform.localScale = Vector3.one * size;
        mr.sharedMaterial.mainTextureScale = originalScale * size;
        Camera.main.orthographicSize = 3 * size;
    }
}