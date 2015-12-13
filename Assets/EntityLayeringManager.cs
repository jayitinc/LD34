using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityLayeringManager : MonoBehaviour
{
    private List<SpriteRenderer> entities = new List<SpriteRenderer>();

    private void Update()
    {
        entities.Clear();

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Entity");

        for (int i = 0; i < gos.Length; i++)
        {
            SpriteRenderer sr = gos[i].GetComponent<SpriteRenderer>();

            if (sr != null)
                entities.Add(sr);
        }

        entities.Sort((a, b) => a.GetComponent<EntityInfo>().size.CompareTo(b.GetComponent<EntityInfo>().size));

        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].sortingOrder = i;
        }
    }
}