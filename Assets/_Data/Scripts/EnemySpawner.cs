using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] private List<GameObject> enemySpawners;
    private GameObject enemyCurrent;

    private void Start()
    {
        base.spawnDelay = 4f;
        base.coutObject = 1;
    }
    private void Update()
    {
        if (Time.time % 40 == 0 && base.coutObject < 5) base.coutObject++;

        this.enemyCurrent = this.enemySpawners[Random.Range(0, enemySpawners.Count)];
        base.objectPrefab = this.enemyCurrent;
        this.RandomPos();
        Invoke(nameof(this.Spawn), 5f);
        base.CheckObjectExplode();
    }
    protected override void Spawn()
    {
        base.Spawn();
    }

    protected virtual void RandomPos()
    {
        base.xPos = Random.Range(-5f, 5f);
        base.yPos = Camera.main.transform.position.y + 30f + Random.value * 20f;
    }
}
