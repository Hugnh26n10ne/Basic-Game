using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public virtual void Despawn()
    {
        Destroy(gameObject);
    }
}
