using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownStunHandler : MonoBehaviour
{
    private float currentTime = 0f;

    private void Awake()
    {
        currentTime = GetComponent<Slider>().maxValue;
    }
    private void Update()
    {
        CoolDownHandler();
        Destroy(gameObject, GetComponent<Slider>().maxValue);
    }

    public void CoolDownHandler()
    {
        if (PlayerController.instance.playerMovement.GetStunStatus())
        {
            if(currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                GetComponent<Slider>().value = currentTime;
                transform.Find("TimeDelay").transform.GetComponent<TextMeshProUGUI>().text = $"{currentTime.ToString("F1")}s";

            }
        }
    }

    public void SetTimeDelay(float time)
    {
        GetComponent<Slider>().maxValue = time;
        GetComponent<Slider>().value = time;
    }
}
