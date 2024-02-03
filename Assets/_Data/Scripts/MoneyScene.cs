using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyScene : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey("bestMoney"))
        {
            PlayerPrefs.SetFloat("bestMoney", 0);
        }
    }
    private void LateUpdate()
    {
        SetMoneyText((float)PlayerStats.Instance.coins);
    }
    public void SetMoneyText(float money)
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = $"{money}";
        if(PlayerPrefs.GetFloat("bestMoney") < money)
        {
            PlayerPrefs.SetFloat("bestMoney", money);
        }
    }
}
