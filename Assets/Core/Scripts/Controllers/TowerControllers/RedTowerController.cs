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
}
