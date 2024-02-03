using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        this.slider = GetComponent<Slider>();
    }
    public void SetMaxHealth(double health)
    {
        this.slider.maxValue = (float)health;
        this.slider.value = (float)health;
    }
    public void SetHealth(double health)
    {
        this.slider.value = (float)health;
    }
}
