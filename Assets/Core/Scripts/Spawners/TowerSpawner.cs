using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public List<GameObject> towerTransformList;

    public List<GameObject> towerTileGameObjects;
    
    [SerializeField] GameObject[] towerPrefabs;
    [SerializeField] GameObject towerParent;

    public int redTowerCost = 15, greenTowerCost = 25, blueTowerCost = 50;

    public void SpawnRedTowersAtRandom()
    {
        SpawnAndSpend(towerPrefabs[0], redTowerCost);
    }
    public void SpawnGreenTowersAtRandom()
    {
        SpawnAndSpend(towerPrefabs[1], greenTowerCost);
    }
    public void SpawnBlueTowersAtRandom()
    {
        SpawnAndSpend(towerPrefabs[2], blueTowerCost);
    }

    private void SpawnAndSpend(GameObject towerPrefab, int cost)
    {
        if (GameManager.Instance.wallet >= cost)
        {
            int randomPosIndex = Random.Range(0, towerTransformList.Count);

            GameObject go = Instantiate(towerPrefab, towerTransformList[randomPosIndex].transform.position, Quaternion.identity);
            go.transform.parent = towerParent.transform;

            towerTransformList[randomPosIndex].GetComponent<TowerTileController>().hasTowerOn = true;

            // Spend gold
            GameManager.Instance.wallet -= cost;

            if (towerTransformList.Count <= 0)
            {
                Debug.Log("No empty tower tile and total tower count: " + towerParent.transform.childCount);
                return;
            }

            AudioManager.instance.PlaySound("TowerPlace");
        }
        else
        {
            AudioManager.instance.PlaySound("TowerPlaceFail");
        }
    }

}
