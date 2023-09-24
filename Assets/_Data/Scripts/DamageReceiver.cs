using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{

    [SerializeField] double hp = 10;


    public virtual bool IsDead()
    {
        return hp <= 0;
    }
    public virtual void Receive(float damage)
    {
        if (this.hp <= 0) return;

        this.hp -= damage;
        this.hp = Math.Round(this.hp,2);
    }
}
