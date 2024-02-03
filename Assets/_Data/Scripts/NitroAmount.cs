using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroAmount : MonoBehaviour
{

    [SerializeField] protected float powerPercent = 0;
    private int powerValue;


    void Awake()
    {
        SetPowerValue();
    }

    public void SetPowerValue()
    {
        this.powerValue = (int)Mathf.Ceil(Random.Range(this.powerPercent - 10, this.powerPercent + 1));
    }

    public int GetPowerValue()
    {
        return this.powerValue;
    }
}
