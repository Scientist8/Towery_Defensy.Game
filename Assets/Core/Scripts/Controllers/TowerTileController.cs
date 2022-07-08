using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTileController : MonoBehaviour
{
    [SerializeField] TowerSpawner towerSpawner;

    public bool hasTowerOn = false;

    private void Start()
    {
        towerSpawner = FindObjectOfType<TowerSpawner>();
    }
    void FixedUpdate()
    {
        if (hasTowerOn)
        {
            towerSpawner.towerTransformList.Remove(this.gameObject);
        }
    }
}
