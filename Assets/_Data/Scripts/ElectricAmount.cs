using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricAmount : MonoBehaviour
{
    [SerializeField] protected float electricPercent = 0;
    private int electricValue;
    void Awake()
    {
        SetElectricValue();
    }

    public void SetElectricValue()
    {
        this.electricValue = (int)Mathf.Ceil(Random.Range(this.electricPercent - 5, this.electricPercent + 6));
    }

    public int GetElectricValue()
    {
        return this.electricValue;
    }
}
