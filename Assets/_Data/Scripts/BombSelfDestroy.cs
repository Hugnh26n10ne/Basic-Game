using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSelfDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Destroy), 12f);
    }

    // Update is called once per frame
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
