using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricSpawner : Spawner
{
    [SerializeField] public List<GameObject> electricPrefabList;
    public GameObject electricCurrent;

    void Start()
    {
        base.spawnDelay = 5f;
        base.coutObject = 3;
    }

    // Update is called once per frame
    void Update()
    {
        this.electricCurrent = electricPrefabList[Random.Range(0, electricPrefabList.Count)];
        base.objectPrefab = this.electricCurrent;

        this.RandomPos();
        this.Spawn();
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
