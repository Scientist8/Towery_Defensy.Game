using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    private Transform target;
    private int wayPointIndex = 0;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        target = WayPoints.points[0];
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = target.position - transform.position;

        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        TurnDirection();
    }

    private void GetNextWayPoint()
    {
        wayPointIndex += 1;

        if (wayPointIndex >= WayPoints.points.Length)
        {
            Debug.Log("Game Over!!!");
            Destroy(gameObject);
        }
        else
        {
            target = WayPoints.points[wayPointIndex];
        }
    }

    private void TurnDirection()
    {
        if (transform.position.x > target.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
