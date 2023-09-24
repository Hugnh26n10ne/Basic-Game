using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{

    protected float damage;
    protected EnemyController enemyCtrl;

    // Start is called before the first frame update
    void Start()
    {
        this.enemyCtrl = gameObject.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        damage = Random.Range(0f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* Player */

        DamageReceiver damageReceiver = collision.GetComponent<DamageReceiver>();
        if (damageReceiver != null)
        {
            this.enemyCtrl.despawner.Despawn();
            damageReceiver.Receive(damage);
        }

        /* Bomb */

        // C1: 

        
        BombSelfDestroy bombSelfDestroy = collision.GetComponent<BombSelfDestroy>();
        if (bombSelfDestroy != null)
        {
            this.enemyCtrl.despawner.Despawn();
            bombSelfDestroy.Destroy();
        }
        
        // C2

        /*
        if (collision.gameObject.CompareTag("Bomb"))
        {
            this.enemyCtrl.despawner.Despawn();
            collision.gameObject.GetComponent<BombSelfDestroy>().Destroy();
        }
        */


    }


}
