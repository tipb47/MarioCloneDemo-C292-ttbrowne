using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    [SerializeField] float patrolSpeed;
    public GameObject platform;

    private float leftEdge;
    private float rightEdge;

    private bool movingLeft = true;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Patrol();
        CalculatePlatformEdges();
    }

    private void Patrol()
    {
        
        if (movingLeft)
        {
            // check if the enemy has reached the left edge
            if (transform.position.x > leftEdge)
            {
                rb.velocity = new Vector2(-patrolSpeed, rb.velocity.y);
            }
            else
            {
                // change direction bool
                movingLeft = false;
            }
        }
        else
        {
            // check if the enemy has reached the right edge
            if (transform.position.x < rightEdge)
            {
                rb.velocity = new Vector2(patrolSpeed, rb.velocity.y);
            }
            else
            {
                // change again
                movingLeft = true;
            }
        }
    }

    private void CalculatePlatformEdges()
    {
        // get platform collider
        Collider2D platformCollider = platform.GetComponent<Collider2D>();
        if (platformCollider != null)
        {
            // get bounds
            Bounds platformBounds = platformCollider.bounds;

            // set left and right edges for enemy
            leftEdge = platformBounds.min.x;
            rightEdge = platformBounds.max.x;
        }
    }
}
