using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySender : MonoBehaviour
{
    private MoneyAmount moneyAmount;
    private void Awake()
    {
        this.moneyAmount = GetComponent<MoneyAmount>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Người chơi CHẾT thì sẽ dừng cộng tiền
        if (PlayerController.instance.damageReceiver.IsDead()) return;

        if (collision.CompareTag("Player"))
        {
            PlayerMoneyReceiver moneyReceiver = collision.GetComponentInChildren<PlayerMoneyReceiver>();
            if (moneyReceiver != null)
            {
                moneyReceiver.Receive(this.moneyAmount.GetMoneyValue());
            }
        }
    }
}
