using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipperController : EnemyControllerParent
{
    [SerializeField] HealthbarController healthbarController;

    [SerializeField] GameObject skipperDeathParticle;

    public float skipperHealth;
    public int skipperGoldToGive;

    private void Start()
    {
        enemyCurrentHealth = skipperHealth;
        goldToGive = skipperGoldToGive;
        healthbarController.UpdateHealthBar(skipperHealth, enemyCurrentHealth);
    }
    private void Update()
    {
        healthbarController.UpdateHealthBar(skipperHealth, enemyCurrentHealth);

        Die();

        if (isDead)
        {
            AudioManager.instance.PlaySound("SkipperDeath");
            InstantiateDeathParticleEffect(skipperDeathParticle);            
        }
    }
}
