using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] public BombSpawner bombSpawner;

    private void Awake()
    {
        this.bombSpawner = GetComponent<BombSpawner>();
    }

    private void FixedUpdate()
    {
        this.bombSpawner.Spawn();
        this.bombSpawner.CheckBombExplode();
    }
}
