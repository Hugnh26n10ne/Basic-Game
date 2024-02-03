using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : Spawner
{
    [SerializeField] private List<GameObject> boxSpawners;
    private GameObject originBox;

    void Start()
    {
        base.spawnDelay = 2f;
        base.coutObject = 1;
    }

    void Update()
    {
        if (Time.time  % 30 == 0 && base.coutObject < 5) base.coutObject = base.coutObject++;

        this.originBox = this.boxSpawners[Random.Range(0, boxSpawners.Count)];
        base.objectPrefab = this.originBox;

        this.RandomPos();
        Invoke(nameof(Spawn), 4f);
        base.CheckObjectExplode();
    }

    protected override void Spawn()
    {
        base.Spawn();

    }

    protected virtual void RandomPos()
    {
        base.xPos = Random.Range(-5f, 5f);
        base.yPos = Camera.main.transform.position.y + 20f + Random.value * 20f;
    }
}
