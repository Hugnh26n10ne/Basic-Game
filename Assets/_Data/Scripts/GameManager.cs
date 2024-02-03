using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]private GameObject pauseGame;
    private static float timeOnReturn = 0;



    public static bool startGame { get; set; } = false;

    private void Awake()
    {
        startGame = false;
    }

    private void Start()
    {
        startGame = false;
        this.pauseGame.SetActive(false);
    }
    private void Update()
    {
        GameManager.Instance = this;
    }

    public virtual void ReloadGame()
    {
        timeOnReturn = Time.time;
        PlayerPrefs.SetFloat("ReturnTime", timeOnReturn);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
    public virtual void GoToSceneHome()
    {
        SceneManager.LoadScene(1);
    }

    public static float GetTimeOnReturn()
    {
        return timeOnReturn;
    }

    public void PauseGame()
    {
        AudioSource audioSource = GameObject.Find("PlayManager").GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Pause();
        }

        this.pauseGame.SetActive(true);
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        AudioSource audioSource = GameObject.Find("PlayManager").GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
        this.pauseGame.SetActive(false);
        Time.timeScale = 1;
    }

    
}
