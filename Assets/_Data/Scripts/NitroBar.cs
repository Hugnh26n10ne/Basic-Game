using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NitroBar : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        this.slider = GetComponent<Slider>();
    }
    public void SetNitro(double nitro)
    {
        this.slider.value = (float)nitro;
    }
}
