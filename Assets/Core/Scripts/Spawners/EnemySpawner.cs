using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float _spawnTimer = 2f;

    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _enemyParent;

    private void Start()
    {
        //StartCoroutine(SpawnEnemies());

        InvokeRepeating("Spawnies", 1f, _spawnTimer);
    }

    public IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(_spawnTimer);

        GameObject go = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        go.transform.parent = _enemyParent.transform;
    }

    public void Spawnies()
    {
        GameObject go = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        go.transform.parent = _enemyParent.transform;
    }
}
