using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] private HeathBar heathBar;

    private void Start()
    {
        this.heathBar = GameObject.Find("HeathBar").GetComponent<HeathBar>();
    }
    public virtual bool IsDead()
    {
        return PlayerStats.Instance.hp <= 0;
    }
    public virtual void Receive(float damage)
    {
        if (PlayerStats.Instance.hp <= 0) return;

        PlayerStats.Instance.hp -= damage;
        PlayerStats.Instance.hp = Math.Round(PlayerStats.Instance.hp,2);
        this.heathBar.SetHealth(PlayerStats.Instance.hp);
    }
}
