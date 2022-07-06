using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public List<GameObject> towerTransformList;

    public List<GameObject> towerTileGameObjects;
    
    [SerializeField] GameObject _towerPrefab;
    [SerializeField] GameObject towerParent;

    private void Awake()
    {

    }
    public void SpawnTowersAtRandom()
    {
        int randomPosIndex = Random.Range(0, towerTransformList.Count);

        
        GameObject go = Instantiate(_towerPrefab, towerTransformList[randomPosIndex].transform.position, Quaternion.identity);
        go.transform.parent = towerParent.transform;

        towerTransformList[randomPosIndex].GetComponent<TowerTileController>().hasTowerOn = true;

        if (towerTransformList.Count <= 0)
        {
            Debug.Log("No empty tower tile and total tower count: " + towerParent.transform.childCount);
            return;
        }

    }
}
