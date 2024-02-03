using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [SerializeField] public double maxHp = 10;
    [SerializeField] public double hp = 10;
    [SerializeField] public double mana = 0;
    [SerializeField] public double coins = 0;

    [SerializeField] private HeathBar heathBar;
    [SerializeField] private NitroBar nitroBar;

    
    private void Start()
    {
        this.hp = this.maxHp;
        this.mana = 0;
        this.heathBar.SetMaxHealth(this.maxHp);
        this.nitroBar.SetNitro(this.mana);
    }
    void Update()
    {
        PlayerStats.Instance = this;
    }
}
