using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GonzalesController : EnemyControllerParent
{
    [SerializeField] HealthbarController healthbarController;

    [SerializeField] GameObject gonzalesDeathParticle;

    public float gonzalesHealth;
    public int gonzalesGoldToGive;

    private void Start()
    {
        enemyCurrentHealth = gonzalesHealth;
        goldToGive = gonzalesGoldToGive;
        healthbarController.UpdateHealthBar(gonzalesHealth, enemyCurrentHealth);
    }
    private void Update()
    {
        healthbarController.UpdateHealthBar(gonzalesHealth, enemyCurrentHealth);

        Die();

        if (isDead)
        {
            AudioManager.instance.PlaySound("GonzalesDeath");
            InstantiateDeathParticleEffect(gonzalesDeathParticle);
        }
    }
}
