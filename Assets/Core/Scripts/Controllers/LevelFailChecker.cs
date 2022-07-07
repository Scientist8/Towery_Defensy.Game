using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailChecker : MonoBehaviour
{
    public int enemiesToEndLevel = 3;

    private void Update()
    {
        if (enemiesToEndLevel <= 0)
        {
            GameManager.Instance.gameIsOver = true;
        }
    }
}
