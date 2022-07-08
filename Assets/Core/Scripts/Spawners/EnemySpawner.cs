using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTimer = 3f;
    public float minSpawnTimer = 0.1f;

    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject enemyParent;

    private bool spawn = true;

    private void Update()
    {
        if (spawn)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    public IEnumerator SpawnEnemies()
    {
        GameObject go = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], transform.position, Quaternion.identity);
        go.transform.parent = enemyParent.transform;

        spawn = false;

        yield return new WaitForSeconds(spawnTimer);

        DecreaseSpawnTimerGradually();

        if (spawnTimer <= minSpawnTimer)
        {
            spawnTimer = minSpawnTimer;
        }
        spawn = true;

    }

    private void DecreaseSpawnTimerGradually()
    {
        if (spawnTimer >= 2)
        {
            spawnTimer -= 0.1f;
        }
        else if (spawnTimer >= 1.5f)
        {
            spawnTimer -= 0.05f;
        }
        else if (spawnTimer >= 1)
        {
            spawnTimer -= 0.025f;
        }
        else
        {
            spawnTimer -= 0.01f;
        }
    }
}
