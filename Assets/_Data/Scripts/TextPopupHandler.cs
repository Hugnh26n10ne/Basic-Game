using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPopupHandler : MonoBehaviour
{
    [SerializeField] private float DestroyTime = 4f;
    [SerializeField] private Vector3 offSet = new Vector3(0, 0.5f, 0);
    [SerializeField] private Vector3 randomizeIntensity = new Vector3(0.5f, 0, 0);
    private void Start()
    {
        Destroy(gameObject, DestroyTime);
        gameObject.transform.localPosition += offSet;
        gameObject.transform.localPosition += new Vector3(  Random.Range(-randomizeIntensity.x, randomizeIntensity.x),
                                                            Random.Range(-randomizeIntensity.y , randomizeIntensity.y),
                                                            Random.Range(-randomizeIntensity.z , randomizeIntensity.z));

    }  
}
