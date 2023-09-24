using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefabs;


    protected float spawnTimer = 0f;
    protected float spawnDelay = 2f;

    private void Awake()
    {
        this.enemyPrefabs = GameObject.Find("Enemy");
        this.enemyPrefabs.SetActive(false);

    }

    private void FixedUpdate()
    {
        this.SpawnerEnemy();
    }
    void SpawnerEnemy()
    {
        if (PlayerController.instance.damageReceiver.IsDead()) return;

        this.spawnTimer += Time.fixedDeltaTime;
        if (this.spawnTimer < this.spawnDelay) return;
        this.spawnTimer = 0f;

        GameObject enemy = Instantiate(this.enemyPrefabs);
        enemy.SetActive(true);
        enemy.transform.position = transform.position;
    }

}
