using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapSpawner : MonoBehaviour
{

    public GameObject wavePrefab;
    public Tilemap originalTilemap;

    private float xPos;
    private float yPos;

    private List<GameObject> waves;
    private float coutWave;
    private float spawnTimer = 0f;
    private float spawnDelay = 1f;

    private void Awake()
    {
        this.waves = new List<GameObject>();

        this.coutWave = Random.Range(1, 2);
    }

    void Update()
    {
        this.SpawnWave();
        this.CheckWaveExplode();
        this.RandomPos();
    }

    void SpawnWave()
    {

        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnDelay) return;
        this.spawnTimer = 0f;

        if (this.waves.Count > this.coutWave) return;

        Vector3 newPosition = transform.position;
        newPosition.x = this.xPos;
        newPosition.y = this.yPos;

        GameObject newWave = Instantiate(this.wavePrefab, newPosition, Quaternion.identity);


        TilemapCloner tilemapCloner = newWave.GetComponent<TilemapCloner>();
        if (tilemapCloner != null)
        {
            tilemapCloner.originalTilemap = this.originalTilemap;
        }

        newWave.transform.parent = this.transform;
        newWave.SetActive(true);

        if (newWave.transform.position.x > 9)
        {
            newWave.transform.rotation = Quaternion.Euler(newWave.transform.rotation.x, newWave.transform.rotation.y, 90);
        }
        else
        {
            newWave.transform.rotation = Quaternion.Euler(newWave.transform.rotation.x, newWave.transform.rotation.y, -90);

        }

        this.waves.Add(newWave);

    }

    public virtual void CheckWaveExplode()
    {
        for (int i = 0; i < this.waves.Count; i++)
        {
            GameObject wave = this.waves[i];
            if (wave == null)
            {
                this.waves.RemoveAt(i);
            }
        }
    }

    public void RandomPos()
    {
        if (Random.value > 0.5f)
        {
            this.xPos = Random.Range(9f, 21f);
        }
        else
        {
            this.xPos = Random.Range(-9f, -21f);
        }

        this.yPos = Camera.main.transform.position.y + 25;
    }
}
