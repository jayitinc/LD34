using UnityEngine;
using System.Collections;

public class WorldMaterialManager : MonoBehaviour
{
    public GameObject materialPrefab;
    public GameObject planetPrefab;
    public Transform playerTransform;

    private void Start()
    {
        StartCoroutine(SpawnMaterial());
        StartCoroutine(SpawnPlanet());
    }

    private IEnumerator SpawnMaterial()
    {
        while (true)
        {
            GameObject go = Instantiate(materialPrefab, new Vector2(Random.Range(playerTransform.position.x - 8, playerTransform.position.x + 8), Random.Range(playerTransform.position.y - 8, playerTransform.position.y + 8)), Quaternion.identity) as GameObject;
            go.name = "Space Material";
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator SpawnPlanet()
    {
        while (true)
        {
            GameObject go = Instantiate(planetPrefab, new Vector2(Random.Range(playerTransform.position.x - 8, playerTransform.position.x + 8), Random.Range(playerTransform.position.y - 8, playerTransform.position.y + 8)), Quaternion.identity) as GameObject;
            go.name = "Planet";
            yield return new WaitForSeconds(10f);
        }
    }
}