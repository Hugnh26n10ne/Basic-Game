using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroSpawner : Spawner
{
    [SerializeField] public List<GameObject> nitroPrefabList;
    public GameObject nitroCurrent;

    void Start()
    {
        base.spawnDelay = 5f;
        base.coutObject = 3;
    }

    // Update is called once per frame
    void Update()
    {
        this.nitroCurrent = nitroPrefabList[Random.Range(0, nitroPrefabList.Count)];
        base.objectPrefab = this.nitroCurrent;

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
