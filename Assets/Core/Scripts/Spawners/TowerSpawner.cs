using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] List<Transform> _towerPositions;

    [SerializeField] GameObject _towerPrefab;

    public void SpawnTowersAtRandom()
    {
        int randomPosIndex = Random.Range(0, _towerPositions.Count);

        
        Instantiate(_towerPrefab, _towerPositions[randomPosIndex].position, Quaternion.identity);
    }
}
