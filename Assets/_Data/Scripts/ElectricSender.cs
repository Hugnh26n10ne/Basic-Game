using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSender : MonoBehaviour
{
    private ElectricAmount electricAmount;
    private void Awake()
    {
        this.electricAmount = GetComponent<ElectricAmount>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Người chơi CHẾT thì sẽ dừng gửi nitro
        if (PlayerController.instance.damageReceiver.IsDead()) return;

        if (collision.CompareTag("Player"))
        {
            PlayerElectricReceiver electricReceiver = collision.GetComponentInChildren<PlayerElectricReceiver>();
            if (electricReceiver != null)
            {
                electricReceiver.Receive(this.electricAmount.GetElectricValue());
            }
        }
    }
}
