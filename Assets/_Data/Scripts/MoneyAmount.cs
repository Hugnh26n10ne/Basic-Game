using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyAmount : MonoBehaviour
{

    [SerializeField] protected int amountPercent = 20;
    private int moneyValue; // Giá trị tiền liên quan

    void Awake()
    {
        SetRandomMoneyValue();
    }

    public void SetRandomMoneyValue()
    {
        this.moneyValue = (int)Mathf.Ceil(Random.Range(this.amountPercent - 5, this.amountPercent + 6));
        this.moneyValue = Mathf.Clamp(this.moneyValue, 0, this.amountPercent * 2);
    }
    
    public int GetMoneyValue()
    {
        return this.moneyValue;
    }
}
