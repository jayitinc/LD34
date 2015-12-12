using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour
{
    public MeshRenderer space;

    private void Update()
    {
        space.sharedMaterial.mainTextureOffset = transform.parent.position / 16;
    }
}