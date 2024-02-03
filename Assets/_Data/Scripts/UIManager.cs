using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public SceneManager SceneManager;
    public GameObject settingGame;
    private static int indexScene = 0;
    public float timeOnReturn;

    public virtual void SaveScene()
    {
        indexScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("indexScene", indexScene);
        PlayerPrefs.Save();
    }
    public void SettingGame()
    {
        var settingClone = Instantiate(settingGame);
        settingClone.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void Home()
    {
        SceneManager.LoadScene(1);
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static int GetSceneBack()
    {
        return PlayerPrefs.GetInt("indexScene");
    }
    public void Back()
    {
        if (GameObject.Find("SettingMenu(Clone)") != null)
        {
            Destroy(GameObject.Find("SettingMenu(Clone)"));
        }
    }

}
