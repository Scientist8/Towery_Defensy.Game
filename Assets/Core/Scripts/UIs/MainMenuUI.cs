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

    public void LoadLevel1()
    {
        SceneManagement.Instance.LoadLevel1();
    }
    public void LoadLevel2()
    {
        SceneManagement.Instance.LoadLevel2();
    }
    public void LoadLevel3()
    {
        SceneManagement.Instance.LoadLevel3();
    }
    public void LoadLevel4()
    {
        SceneManagement.Instance.LoadLevel4();
    }
    public void LoadLevel5()
    {
        SceneManagement.Instance.LoadLevel5();
    }
    public void LoadLevel6()
    {
        SceneManagement.Instance.LoadLevel6();
    }
    public void LoadLevel7()
    {
        SceneManagement.Instance.LoadLevel7();
    }
    public void LoadLevel8()
    {
        SceneManagement.Instance.LoadLevel8();
    }
    public void LoadLevel9()
    {
        SceneManagement.Instance.LoadLevel9();
    }
    public void LoadLevel10()
    {
        SceneManagement.Instance.LoadLevel10();
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
