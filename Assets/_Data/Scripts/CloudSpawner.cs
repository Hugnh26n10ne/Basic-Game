using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : Spawner
{
    [SerializeField] protected GameObject cloudPrefab;
    void Awake()
    {
        base.Objects = new List<GameObject>();
        base.objectPrefab = cloudPrefab;
    }

    private void Start()
    {
        base.coutObject = 2;
    }
    void Update()
    {

        this.RandomPos();
        this.Spawn();
        base.CheckObjectExplode();
    }

    protected override void Spawn()
    {
        base.Spawn();
    }

    public void RandomPos()
    {
        if (Random.value > 0.5f)
        {
            base.xPos = Random.Range(-0.12f, 17f);
        }
        else
        {
            base.xPos = Random.Range(-2f, -17f);
        }

        base.yPos = Camera.main.transform.position.y + 20;
    }
}
