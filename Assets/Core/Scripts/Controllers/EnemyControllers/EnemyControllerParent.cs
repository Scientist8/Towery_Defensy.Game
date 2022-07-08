using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerParent : MonoBehaviour
{
    public float enemyCurrentHealth = 10f; // This variable needed in tower controller script
    protected int goldToGive = 10;

    protected bool isDead = false;

    private LevelFailChecker levelFailChecker;
    private void Awake()
    {
        levelFailChecker = FindObjectOfType<LevelFailChecker>();
    }

    protected virtual void Die()
    {
        if (enemyCurrentHealth <= 0)
        {
            GameManager.Instance.GiveGold(goldToGive);
            GameManager.Instance.IncreaseMonsterKillCount();
            levelFailChecker.enemiesToPassLevelHolder--;
            isDead = true;
            Destroy(gameObject);
        }
    }

    protected virtual void InstantiateDeathParticleEffect(GameObject particleSystem)
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);
    }
}
