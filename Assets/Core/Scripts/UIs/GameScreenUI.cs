using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScreenUI : MonoBehaviour
{
    [SerializeField] TMP_Text killCountText, totalKillCountText;
    [SerializeField] TMP_Text walletText;

    [SerializeField] TMP_Text endScreenTotalKillCountText, endScreenKillCountText;

    [SerializeField] GameObject gameScreenPanel;
    [SerializeField] GameObject pauseMenuPanel;
    [SerializeField] GameObject gameOverPanel;

    private void Update()
    {
        killCountText.text = "Monsters Killed: " + GameManager.Instance.monsterKillCount.ToString();
        totalKillCountText.text = "Total Monsters Killed: " + GameManager.Instance.totalMonsterKillCount.ToString();

        walletText.text = "Gold: " + GameManager.Instance.wallet.ToString();

        endScreenKillCountText.text = "Total Slain Monsters: " + GameManager.Instance.monsterKillCount.ToString();
        endScreenTotalKillCountText.text = "Slain Monsters: " + GameManager.Instance.totalMonsterKillCount.ToString();
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
        GameManager.Instance.PauseGame();
        gameScreenPanel.SetActive(false);
        gameOverPanel.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
