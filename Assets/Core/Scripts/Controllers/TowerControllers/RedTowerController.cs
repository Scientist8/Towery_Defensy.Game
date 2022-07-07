using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTowerController : TowerControllerParent
{    
    public float redTowerDamage = 5;
    public float redTowerRange = 3;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        damage = redTowerDamage;
        range = redTowerRange;
    }
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // An expensive calculation so instead of every frame do this every 0.5 seconds

        // Shake it when spawned
        DOTweenShaker.Shake(duration: 0.5f, strength: 0.5f);
    }
}
