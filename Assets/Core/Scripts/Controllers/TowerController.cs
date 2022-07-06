using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public float _damage;

    public Transform _target;
    public float _range;

    public string _enemyTag = "Enemy";

    private void Start()
    {
        // A technical debt
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // An expensive calculation so instead of every frame do this every 0.5 seconds
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
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

        if (nearestEnemy != null && shortestDistance <= _range)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }
    private void Update()
    {
        if (_target == null)
        {
            return;
        }
        else
        {
            _target.GetComponent<EnemyController>().enemyHealth -= _damage;

            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
