using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTowerController : TowerControllerParent
{
    public float blueTowerDamage = 20;
    public float blueTowerRange = 7;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        damage = blueTowerDamage;
        range = blueTowerRange;
    }
}
