using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EntityInfo))]
public class PlayerInfo : MonoBehaviour
{
    private MeshRenderer mr;
    private Vector2 originalScale;
    private EntityInfo ei;

    private int bgDivide = 1;

    private void Start()
    {
        ei = GetComponent<EntityInfo>();
        mr = GetComponentInChildren<MeshRenderer>();
        mr.sharedMaterial.mainTextureOffset = Vector2.zero;
        mr.sharedMaterial.mainTextureScale = Vector2.one;
        originalScale = mr.sharedMaterial.mainTextureScale;
    }

    private void Update()
    {
        if (ei.size < 10)
            bgDivide = 1;
        else if (ei.size < 100)
            bgDivide = 10;

        mr.sharedMaterial.mainTextureScale = originalScale * ei.size;
        Camera.main.orthographicSize = 3 * ei.size;
    }
}