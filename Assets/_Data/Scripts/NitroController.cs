using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroController : MonoBehaviour
{
    public Despawner despawner;

    public NitroAmount nitroAmount;


    private void Awake()
    {
        this.despawner = GetComponent<Despawner>();
        this.nitroAmount = GetComponent<NitroAmount>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            despawner.Despawn();
        }

    }
}
