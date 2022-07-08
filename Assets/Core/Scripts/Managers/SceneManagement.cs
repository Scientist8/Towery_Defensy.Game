using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement Instance { get; private set; }

    private void Awake()
    {
        SingletonThisGameObject();
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
    public void LoadNextLevel()
    {
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currenSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ReloadLevel()
    {
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currenSceneIndex);
    }

    public void LoadLevel0()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadLevel7()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadLevel8()
    {
        SceneManager.LoadScene(8);
    }
    public void LoadLevel9()
    {
        SceneManager.LoadScene(9);
    }
    public void LoadLevel10()
    {
        SceneManager.LoadScene(10);
    }
}
