using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EntityInfo))]
public class Enemy : MonoBehaviour
{
    public float speed = 3;

    private Transform player;
    private EntityInfo playerEI;
    private Rigidbody2D rb;
    private EntityInfo ei;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ei = GetComponent<EntityInfo>();
    }

    private void Update()
    {
        List<RaycastHit2D> hit = new List<RaycastHit2D>(Physics2D.CircleCastAll(transform.position, 5 * ei.size, Vector2.zero));

        bool enemiesExist = false;

        for (int i = 0; i < hit.Count; i++)
        {
            if (hit[i].collider.GetComponent<Enemy>() != null || hit[i].collider.GetComponent<PlayerInfo>() != null)
                enemiesExist = true;
        }

        if (enemiesExist)
        {
            for (int i = 0; i < hit.Count; i++)
            {
                if (hit[i].collider.GetComponent<Enemy>() == null && hit[i].collider.GetComponent<PlayerInfo>() == null)
                    hit.RemoveAt(i);
            }
        }

        //hit.Sort((a, b) => (Vector2.Distance(a.collider.transform.position, transform.position)).CompareTo(Vector2.Distance(b.collider.transform.position, transform.position)));
        hit.Sort((a, b) => a.collider.GetComponent<EntityInfo>().size.CompareTo(b.collider.GetComponent<EntityInfo>().size));

        playerEI = hit[0].collider.GetComponent<EntityInfo>();
        player = hit[0].collider.transform;

        Vector2 playerDifference = player.position - transform.position;
        Vector2 directionVector = playerDifference.normalized;
        Vector2 movementVector = -directionVector * speed;

        if (playerEI.size < ei.size)
        {
            movementVector = directionVector * speed;
        }

        if (movementVector.Equals(Vector2.zero))
        {
            playerEI = hit[1].collider.GetComponent<EntityInfo>();
            player = hit[1].collider.transform;

            playerDifference = player.position - transform.position;
            directionVector = playerDifference.normalized;
            movementVector = -directionVector * speed;
        }
        rb.velocity = movementVector;
    }
}