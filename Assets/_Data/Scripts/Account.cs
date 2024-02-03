
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Account : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TMP_InputField display;

    private void Start()
    {
        text.text = PlayerPrefs.GetString("user_name");
    }

    public void CreateName()
    {
        text.text = display.text;
        PlayerPrefs.SetString("user_name", text.text);
        PlayerPrefs.Save();

        
    }
    public void Login()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
