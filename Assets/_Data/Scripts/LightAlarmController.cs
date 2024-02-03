using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightAlarmController : MonoBehaviour
{
    private Light2D light2D;


    [SerializeField] private float TimeDelay = 0.1f;
    private float Timer = 0f;

    private float intensityRange = 9f; // The range between the minimum and maximum intensity
    private float intensityOffset = 0f;
    [SerializeField] private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        this.light2D = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Timer += Time.deltaTime;
        if (this.Timer > this.TimeDelay)
        {
            this.Timer = 0f;

            Color redColor = new Color(1f, 0f, 0f, 1f);
            Color blueColor = new Color(0f, 0.2078419f, 1f, 1f);

            float t = Mathf.PingPong(Time.time * speed, 1f);
            float newIntensity = intensityOffset + intensityRange * t;

            this.light2D.intensity = newIntensity;


            if (this.light2D.color == redColor)
            {
                this.light2D.color = blueColor;
            }
            else
            {
                this.light2D.color = redColor;
            }

        }
    }
}
