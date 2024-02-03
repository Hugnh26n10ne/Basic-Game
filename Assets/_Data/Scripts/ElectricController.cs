using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricController : MonoBehaviour
{
    private Despawner despawner;
    private ElectricAmount electricAmount;

    private void Awake()
    {
        this.despawner = GetComponent<Despawner>();
        this.electricAmount = GetComponent<ElectricAmount>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            despawner.Despawn();
        }

    }
}
