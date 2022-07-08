using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScreenUI : MonoBehaviour
{
    [SerializeField] TMP_Text killCountText, totalKillCountText;
    [SerializeField] TMP_Text walletText;
    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text killsToPassLevelText;

    [SerializeField] TMP_Text endScreenTotalKillCountText, endScreenKillCountText;

    [SerializeField] LevelFailChecker levelFailChecker;

    [SerializeField] GameObject gameScreenPanel;
    [SerializeField] GameObject pauseMenuPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject levelSuccessPanel;

    public bool playFailSoundOnlyOnce = true;


    private void Update()
    {
        killCountText.text = "Monsters Killed: " + GameManager.Instance.monsterKillCount.ToString();
        totalKillCountText.text = "Total Monsters Killed: " + GameManager.Instance.totalMonsterKillCount.ToString();
        livesText.text = "Lives: " + levelFailChecker.enemiesToFailLevel.ToString();
        killsToPassLevelText.text = "Kills To Pass: " + levelFailChecker.enemiesToPassLevelHolder;

        walletText.text = "Gold: " + GameManager.Instance.wallet.ToString();

        endScreenKillCountText.text = "Slain Monsters: " + GameManager.Instance.monsterKillCount.ToString();
        endScreenTotalKillCountText.text = "Total Slain Monsters: " + GameManager.Instance.totalMonsterKillCount.ToString();

        if (GameManager.Instance.gameIsOver)
        {
            GameOver();

            GameManager.Instance.PauseGame();

            if (playFailSoundOnlyOnce)
            {
                AudioManager.instance.PlaySound("GameOver");
                playFailSoundOnlyOnce = false;
            }
        }

        if (GameManager.Instance.levelPassed)
        {
            LevelSuccessMenuActivate();
            GameManager.Instance.levelPassed = false;
        }
    }

    public void PauseGame()
    {
        GameManager.Instance.PauseGame();
        gameScreenPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }
    public void ResumeGame()
    {
        GameManager.Instance.ResumeGame();
        gameScreenPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameScreenPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    public void ReloadLevel()
    {
        SceneManagement.Instance.ReloadLevel();
        GameManager.Instance.monsterKillCount = 0;
        GameManager.Instance.wallet = 150;
    }

    public void LoadNextLevel()
    {
        SceneManagement.Instance.LoadNextLevel();
        GameManager.Instance.monsterKillCount = 0;
        GameManager.Instance.wallet = 150;
    }


    public void BackToMainMenu()
    {
        SceneManagement.Instance.LoadLevel0();
        GameManager.Instance.monsterKillCount = 0;
        GameManager.Instance.wallet = 150;
    }

    public void LevelSuccessMenuActivate()
    {
        GameManager.Instance.PassLevel();
        gameScreenPanel.SetActive(false);
        levelSuccessPanel.SetActive(true);
    }

    public void LevelSuccesMenuDeactivate()
    {
        GameManager.Instance.ResumeGame();
        gameScreenPanel.SetActive(true);
        levelSuccessPanel.SetActive(false);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
