using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] float timeStartGame = 0;
    [SerializeField] TextMeshProUGUI countDownDisplay;
    [SerializeField] Animator animCountDown;

    private void Start()
    {
        StartCoroutine(CountDownToStart());
    }

    IEnumerator CountDownToStart()
    {
        while (timeStartGame > 0)
        {
            countDownDisplay.gameObject.SetActive(true);
            countDownDisplay.text = timeStartGame.ToString();
            yield return new WaitForSeconds(0.7f);
            countDownDisplay.gameObject.SetActive(false);

            timeStartGame--;
        }
        countDownDisplay.gameObject.SetActive(true);
        countDownDisplay.text = "GO!";
        GameManager.startGame = true;

        yield return new WaitForSeconds(1f);

        countDownDisplay.gameObject.SetActive(false);
    }
}
