using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControllerParent : MonoBehaviour
{
    protected float damage;    
    protected float range;

    public string enemyTag = "Enemy";

    public Transform target;

    protected LineRenderer lineRenderer;

    private void Awake()
    {
        
    }
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // An expensive calculation so instead of every frame do this every 0.5 seconds
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void Update()
    {
        if (target == null)
        {
            lineRenderer.enabled = false;
            return;
        }
        else
        {
            target.GetComponent<EnemyControllerParent>().enemyCurrentHealth -= damage;

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, new Vector3(target.position.x, target.position.y, 0));
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
