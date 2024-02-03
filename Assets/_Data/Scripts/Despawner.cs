using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    void Start()
    {
       // Invoke(nameof(Despawn), 20f);
    }
    void Update()
    {
        if (Mathf.Abs(Camera.main.transform.position.y - transform.position.y) > 45)
        {
            Invoke(nameof(Despawn), 2f);
        };
        if (Mathf.Abs(transform.position.x) > 30)
        {
            Invoke(nameof(Despawn), 4f);
        };
    }

    public virtual void Despawn()
    {
        Destroy(gameObject);
    }
}
