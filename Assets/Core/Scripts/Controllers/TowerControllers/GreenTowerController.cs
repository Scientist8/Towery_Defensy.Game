using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTowerController : TowerControllerParent
{
    public float GreenTowerDamage = 10;
    public float GreenTowerRange = 5;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        damage = GreenTowerDamage;
        range = GreenTowerRange;
    }
}
