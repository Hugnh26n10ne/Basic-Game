using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerEffect : MonoBehaviour
{

    public void UpdateScale()
    {
        gameObject.transform.localScale = Vector3.one * 3;
    } 
}
