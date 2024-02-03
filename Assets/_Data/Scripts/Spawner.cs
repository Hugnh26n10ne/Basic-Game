using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    protected GameObject objectClone;
    protected GameObject objectPrefab;
    protected GameObject objectCurrent;
    protected List<GameObject> Objects;
    protected string nameOject;
    protected float coutObject;
    protected float xPos;
    protected float yPos;

    protected float spawnDelay;
    protected float spawnTimer;

    private void Awake()
    {
        this.nameOject = "";
        this.coutObject = 0;
        this.Objects = new List<GameObject> ();
    }


    protected virtual void Spawn()
    {
        // Người chơi CHẾT thì  sẽ dừng Spawn 
        if (PlayerController.instance.playerStats.hp < 0) return;

        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnDelay) return;
        this.spawnTimer = 0f;
        if (this.Objects.Count > this.coutObject) return;

        Vector2 objectPos = transform.position;
        objectPos.x = xPos;
        objectPos.y = yPos;

        this.objectClone = Instantiate(this.objectPrefab, objectPos, Quaternion.identity);
        objectClone.SetActive(true);
        objectClone.transform.parent = this.transform;

        this.Objects.Add(objectClone);
    }

    protected virtual void Spawn(Vector3 position)
    {
        if (PlayerController.instance.damageReceiver.IsDead()) return;
        this.objectCurrent = Instantiate(objectPrefab, position, this.objectPrefab.transform.rotation);
        this.objectCurrent.SetActive(true);
        this.objectCurrent.transform.parent = transform;
        this.Objects.Add(objectCurrent);
    }


    public virtual void CheckObjectExplode()
    {
        for (int i = 0; i < this.Objects.Count; i++)
        {
            GameObject road = this.Objects[i];
            if (road == null)
            {
                this.Objects.RemoveAt(i);
            }
        }
    }

}
