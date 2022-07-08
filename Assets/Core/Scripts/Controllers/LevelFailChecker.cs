using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailChecker : MonoBehaviour
{
    public int enemiesToFailLevel = 3;
    
    public int enemiesToPassLevelMax = 150; 
        [HideInInspector] public int enemiesToPassLevel, enemiesToPassLevelHolder;

    private bool passLevelOnlyOnce = true;

    private void Start()
    {
        enemiesToPassLevelHolder = enemiesToPassLevelMax;
        GameManager.Instance.gameIsOver = false;
    }
    private void FixedUpdate()
    {
        enemiesToPassLevel = GameManager.Instance.monsterKillCount;

        if (enemiesToFailLevel <= 0)
        {
            GameManager.Instance.gameIsOver = true;
        }

        if (enemiesToPassLevel >= enemiesToPassLevelMax)
        {
            if (passLevelOnlyOnce)
            {
                GameManager.Instance.levelPassed = true;
                passLevelOnlyOnce = false;
            }
        }
    }
}
