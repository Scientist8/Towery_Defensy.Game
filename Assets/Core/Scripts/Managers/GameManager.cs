using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static bool gameIsPaused = false;
    public bool gameIsOver = false;
    public bool levelPassed = false;

    public int totalMonsterKillCount, monsterKillCount;
    public int wallet = 150;

    private void Awake()
    {
        SingletonThisGameObject();

        ResumeGame(); // Had a little bug when the level fails and reloads the scene time.timescale wouldn't turn back to 1, this fixed it for the moment
    }
    private void Start()
    {
        // Get kill count
        totalMonsterKillCount = SaveManager.instance.totalKillCount;
    }

    public void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void GiveGold(int goldToGive)
    {
        wallet += goldToGive;
    }

    public void SpendGold(int goldToSpend)
    {
        wallet -= goldToSpend;
    }

    public void IncreaseMonsterKillCount()
    {
        monsterKillCount++;
        totalMonsterKillCount++;

        // Save this variable in a binary file, why not just use playerprefs?
        SaveManager.instance.totalKillCount = totalMonsterKillCount;
        SaveManager.instance.Save();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void PassLevel()
    {
        levelPassed = true;
        Time.timeScale = 0.2f;
    }
}
