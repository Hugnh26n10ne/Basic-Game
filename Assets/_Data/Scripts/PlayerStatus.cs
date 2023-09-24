using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject gameOver;
    private void Awake()
    {
        this.playerController  = GetComponent<PlayerController>();
        this.gameOver = GameObject.Find("btnGameOver");
        gameOver.SetActive(false);
    }

    public virtual void Dead()
    {
        gameOver.SetActive(true);
    }
}
