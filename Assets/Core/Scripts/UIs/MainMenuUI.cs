using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel, infoPanel, levelsPanel;

    [SerializeField] TMPro.TMP_Text totalSlainMonstersText;

    private void Start()
    {
        totalSlainMonstersText.text = "Total Slain Monsters: " + GameManager.Instance.totalMonsterKillCount.ToString();
    }

    public void LevelsButton()
    {
        mainMenuPanel.SetActive(false);
        levelsPanel.SetActive(true);
    }

    public void LevelsBackButton()
    {
        mainMenuPanel.SetActive(true);
        levelsPanel.SetActive(false);
    }

    public void InfoButton()
    {
        mainMenuPanel.SetActive(false);
        infoPanel.SetActive(true);
    }

    public void InfoBackButton()
    {
        mainMenuPanel.SetActive(true);
        infoPanel.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
