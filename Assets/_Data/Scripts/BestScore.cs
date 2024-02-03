using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("bestMoney").ToString();
    }
}
