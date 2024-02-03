using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool hasCollision { get; set; } = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasCollision = true;
            collision.gameObject.transform.Find("ExplosionEffect").GetComponent<PlayerEffect>().UpdateScale();
            collision.gameObject.transform.Find("ExplosionEffect").GetComponent<Animator>().SetBool("hasExplosion", true);
            collision.gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
