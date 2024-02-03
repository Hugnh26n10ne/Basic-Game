using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParameterReceivers : MonoBehaviour
{
    public virtual void Receive(float coin)
    {
        if (PlayerController.instance.playerStats.hp < 0) return;

        PlayerStats.Instance.coins += coin;
        PlayerStats.Instance.coins = Math.Round(PlayerStats.Instance.coins, 2);
    }
}
