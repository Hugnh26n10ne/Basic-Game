using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] protected GameObject BombPrefab;
    [SerializeField] protected List<GameObject> Bombs;
    [SerializeField] protected GameObject Player;


    private float indexBomb;
    private float countBomb;
    private float spawnTimer = 0f;
    private float spawnDelay = 1f;

    private void Awake()
    {
        this.Bombs = new List<GameObject>();
        this.indexBomb = 0;
        this.countBomb = Random.Range(5,15);

        this.BombPrefab = GameObject.Find("Bomb");
        this.BombPrefab.SetActive(false);


        this.Player = GameObject.Find("Player");
    }

    public virtual void Spawn()
    {
        if (PlayerController.instance.damageReceiver.IsDead()) return;
        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnDelay) return;
        this.spawnTimer = 0f;

        if (this.Bombs.Count > this.countBomb) return;

        GameObject bomb = Instantiate(BombPrefab);
        bomb.SetActive(true);
        bomb.name = "Bomb " + indexBomb;
        bomb.transform.position = this.Player.transform.position;


        this.Bombs.Add(bomb);
        this.indexBomb++;
    }

    public virtual void CheckBombExplode()
    {
        for (int i = 0; i < this.Bombs.Count; i++)
        {
            GameObject bomb = this.Bombs[i];
            if (bomb == null)
            {
                this.Bombs.RemoveAt(i);
                if (GameObject.Find("Bomb " + i) == null)
                {
                    this.indexBomb = i ;
                }
            }
        }
    }
}
