using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoneySpawner : Spawner
{
    [SerializeField] public List<GameObject> moneyPrefabList;
    public GameObject moneyCurrent;

    void Start()
    {
        base.spawnDelay = 5f;
        base.coutObject = 3;
    }

    // Update is called once per frame
    void Update()
    {
        this.moneyCurrent = moneyPrefabList[Random.Range(0, moneyPrefabList.Count)];
        base.objectPrefab = this.moneyCurrent;

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

    public virtual void SetValueMoney()
    {
        
        MoneyAmount moneyAmount = moneyCurrent.GetComponent<MoneyAmount>();
        if (moneyAmount != null)
        {
            moneyAmount.SetRandomMoneyValue();

        }
    }
}
