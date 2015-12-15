using UnityEngine;
using System.Collections;

public class WorldMaterialManager : MonoBehaviour
{
    public GameObject materialPrefab;
    public GameObject planetPrefab;
    public Transform playerTransform;

    private EntityInfo playerEI;

    private void Start()
    {
        playerEI = playerTransform.gameObject.GetComponent<EntityInfo>();

        StartCoroutine(SpawnMaterial());
        StartCoroutine(SpawnPlanet());
    }

    private IEnumerator SpawnMaterial()
    {
        while (true)
        {
            if (!Game.PAUSED)
            {
                GameObject go = Instantiate(materialPrefab, new Vector2(Random.Range(playerTransform.position.x - (8 * playerEI.size), playerTransform.position.x + (8 * playerEI.size)), Random.Range(playerTransform.position.y - (8 * playerEI.size), playerTransform.position.y + (8 * playerEI.size))), Quaternion.identity) as GameObject;
                go.name = "Space Material";
                EntityInfo ei = go.GetComponent<EntityInfo>();

                int particleType = (int)Random.Range(0, 3);

                switch (particleType)
                {
                    case 0:
                        ei.resources.water = 1;
                        ei.resources.oxygen = 0;
                        ei.resources.iron = 0;
                        break;
                    case 1:
                        ei.resources.water = 0;
                        ei.resources.oxygen = 1;
                        ei.resources.iron = 0;
                        break;
                    case 2:
                        ei.resources.water = 0;
                        ei.resources.oxygen = 0;
                        ei.resources.iron = 1;
                        break;
                    default:
                        ei.resources.water = 1;
                        ei.resources.oxygen = 0;
                        ei.resources.iron = 0;
                        break;
                }

                
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator SpawnPlanet()
    {
        while (true)
        {
            if (!Game.PAUSED)
            {
                GameObject go = Instantiate(planetPrefab, new Vector2(Random.Range(playerTransform.position.x - (8 * playerEI.size), playerTransform.position.x + (8 * playerEI.size)), Random.Range(playerTransform.position.y - (8 * playerEI.size), playerTransform.position.y + (8 * playerEI.size))), Quaternion.identity) as GameObject;
                go.name = "Planet";
                EntityInfo goEI = go.GetComponent<EntityInfo>();
                float size = Random.Range(1, playerEI.size + 5);
                goEI.size = size;
                
            }

            yield return new WaitForSeconds(10f);
        }
    }
}