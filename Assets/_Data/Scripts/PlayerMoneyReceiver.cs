using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoneyReceiver : ParameterReceivers
{
    [SerializeField] private GameObject textPrefabs;
    public override void Receive(float coin)
    {
        base.Receive(coin);
        var textMoney = Instantiate(textPrefabs, transform.position, Quaternion.identity, transform);
        textMoney.GetComponent<TextMesh>().text = $"+{coin:F2} 💵";
        textMoney.GetComponent<TextMesh>().color = Color.yellow;
    }
}
