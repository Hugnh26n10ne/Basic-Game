using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    static public PlayerController instance;

    public DamageReceiver damageReceiver;
    public DamageSender damageSender;
    public PlayerStatus playerStatus;
    public PlayerStats playerStats;
    public PlayerMovement playerMovement;


    private void Awake()
    {
        PlayerController.instance = this;
        this.damageReceiver = GetComponent<DamageReceiver>();
        this.damageSender = GetComponent<DamageSender>();
        this.playerStatus = GetComponent<PlayerStatus>();
        this.playerStats = GetComponent<PlayerStats>();
        this.playerMovement = GetComponent<PlayerMovement>();

    }
}
