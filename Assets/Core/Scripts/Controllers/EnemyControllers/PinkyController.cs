using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkyController : EnemyControllerParent
{
    [SerializeField] HealthbarController healthbarController;

    public float pinkyHealth;
    public int pinkyGoldToGive;

    private void Start()
    {
        enemyCurrentHealth = pinkyHealth;
        goldToGive = pinkyGoldToGive;
        healthbarController.UpdateHealthBar(pinkyHealth, enemyCurrentHealth);
    }

    private void Update()
    {
        healthbarController.UpdateHealthBar(pinkyHealth, enemyCurrentHealth);

        Die();

        if (isDead)
        {
            AudioManager.instance.PlaySound("PinkyDeath");
        }
    }
}
