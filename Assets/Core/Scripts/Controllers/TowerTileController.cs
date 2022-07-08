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
    void Update()
    {
        if (hasTowerOn)
        {
            towerSpawner.towerTransformList.Remove(this.gameObject);
        }
    }
}
