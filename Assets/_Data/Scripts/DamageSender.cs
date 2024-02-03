using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{

    protected float damage = 0f;
    protected BoxController boxCtrl;

    [Header("Collision")]
    private bool hasCollidedStun = false;

    [Header("Boss")]
    private GameObject boss;



    void Start()
    {
        this.boxCtrl = gameObject.GetComponent<BoxController>();
        this.boss = GameObject.Find("Police");

    }

    private void FixedUpdate()
    {
        damage = Random.Range(0f, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Người chơi CHẾT thì sẽ dừng gửi damage
        if (PlayerController.instance.playerStats.hp < 0) return;

        PlayerDamageReceiver playerDamageReceiver = collision.gameObject.GetComponent<PlayerDamageReceiver>();

        if (playerDamageReceiver != null)
        {
            float damageConservation = 0f;

            if (gameObject.CompareTag("BoxDestroy"))
            {
                damageConservation = damage / 2;

                if (collision.gameObject.CompareTag("Player") && !PlayerController.instance.playerStatus.hasCollided)
                {
                    PlayerController.instance.playerStatus.hasCollided = true;

                }
            }
            if (gameObject.CompareTag("CarNoDestroy"))
            {

                damageConservation = damage;

                if (!PlayerController.instance.playerMovement.GetStunStatus() && !hasCollidedStun)
                {
                    PlayerController.instance.playerStatus.Stun(3f);
                    hasCollidedStun = true;
                }
            }
            if (gameObject.CompareTag("Boss"))
            {
                damageConservation = 100;
            }

            if (gameObject.CompareTag("Enemy"))
            {
                damageConservation = 100;
            }

            playerDamageReceiver.Receive(damageConservation);

            this.boss.gameObject.GetComponent<BossFollow>().setDisLimit(1f);
            this.boss.gameObject.transform.Find("Sprite").gameObject.SetActive(true);
            this.boss.gameObject.GetComponent<BossFollow>().isHasCollided = true;
        }


    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        // Người chơi CHẾT thì dừng va chạm
        if (PlayerController.instance.damageReceiver.IsDead()) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            if (hasCollidedStun && !PlayerController.instance.playerMovement.GetStunStatus())
            {
                hasCollidedStun = false;
            }
            if (this.boss.gameObject.GetComponent<BossFollow>().isHasCollided)
            {
                this.boss.gameObject.GetComponent<BossFollow>().isHasCollided = false;
            }

        }
    }
}
