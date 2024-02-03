using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public Despawner despawner;

    public MoneyAmount moneyAmount;

    public float speed = 5f;
    bool moveCoin;
    GameObject target;


    private void Awake()
    {
        this.despawner = GetComponent<Despawner>();
        this.moneyAmount = GetComponent<MoneyAmount>();
    }
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("toCoins");
    }


    private void Update()
    {
        if (moveCoin)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            moveCoin = true;
            Invoke(nameof(Destroy),1f);
        }

    }
    void Destroy()
    {
        despawner.Despawn();
    }
}
