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
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // An expensive calculation so instead of every frame do this every 0.5 seconds

        // Shake it when spawned
        DOTweenShaker.Shake(duration: 0.5f, strength: 0.5f);
    }
}
