using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float _moveSpeed = 10f;

    private Transform _target;
    private int _wayPointIndex = 0;

    private void Start()
    {
        _target = WayPoints.points[0];
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;

        transform.Translate(direction.normalized * _moveSpeed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        _wayPointIndex += 1;

        if (_wayPointIndex >= 17)
        {
            Destroy(gameObject);
        }
        else
        {
            _target = WayPoints.points[_wayPointIndex];
        }

    }
}
