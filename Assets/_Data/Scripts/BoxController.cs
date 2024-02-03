using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] private Despawner despawner;
    [SerializeField] private Animator anim;

    private void Awake()
    {        
        this.despawner = GetComponent<Despawner>();
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.anim.SetBool("boxdestroy", true);
        }

    }


    private IEnumerator DelayedDespawn(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);

        this.despawner.Despawn();
    }

}
