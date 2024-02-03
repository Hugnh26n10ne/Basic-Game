using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroSender : MonoBehaviour
{
    private NitroAmount nitroAmount;
    private void Awake()
    {
        this.nitroAmount = GetComponent<NitroAmount>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Người chơi CHẾT thì sẽ dừng cộng nitro
        if (PlayerController.instance.damageReceiver.IsDead()) return;

        if (collision.CompareTag("Player"))
        {
            PlayerNitroReceiver nitroReceiver = collision.GetComponentInChildren<PlayerNitroReceiver>();
            if (nitroReceiver != null)
            {
                nitroReceiver.Receive(this.nitroAmount.GetPowerValue());
            }
        }
    }
}
