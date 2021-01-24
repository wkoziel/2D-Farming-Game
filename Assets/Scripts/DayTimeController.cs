using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class DayTimeController : MonoBehaviour
{
    const float SecondsInDay = 86400f;
    public float time;
    [SerializeField] Text TimeDisplay;
    [SerializeField] float TimeScale;
    [SerializeField] float LightTransition = 0.0001f;
    public int hungerUpdaterCounter;
    public int healthUpdaterCounter;

    private void Start()
    {
        time = 25200f;
        hungerUpdaterCounter = 0;
        healthUpdaterCounter = 0;
    }
    private float getHours
    {
        get { return time / 3600f; }
    }

    public float GetTime
    {
        get { return time; }
    }


    void Update()
    {
        //próba wskaźnika głodu
        hungerUpdaterCounter += 1;
        //tutaj dostosowac jak szybko maleje wskaznik najedzenia
        if (hungerUpdaterCounter == 600)
        {
            HungerController.currentHunger -= 1;
            hungerUpdaterCounter = 0;
        }
        //gdy wskaźnik najedzenia jest niższy niż 15, zaczyna ubywać zdrowia:
        if(HungerController.currentHunger < 30)
        {
            healthUpdaterCounter += 1;
            //tutaj dostosowac jak szybko maleje wskaznik zdrowia
            if (healthUpdaterCounter == 300)
            {
                HealthController.currentHealth -= 1;
                healthUpdaterCounter = 0;
            }
        }
        

        time += Time.deltaTime * TimeScale;
        int hours = (int)getHours;
        TimeDisplay.text = hours.ToString("00") + ":00";
        Light2D light = transform.GetComponent<Light2D>();

        //Day light
        if (time > 25200f && time < 72000f)
        {
            light.intensity = 1f;
            //proba wskaznika temperatury
            TemperatureController.currentTemperature = 80;
        }
        //Lights down 20 - 4
        if ((time > 72000f && time < 86400f) || ((time > 0f && time < 14400f)))
            if (light.intensity > 0.3f)
            {
                light.intensity -= LightTransition;
                //proba wskaznika temperatury
                TemperatureController.currentTemperature = 40;

            }
        //Lights up 4 - 7
        if (time > 14400f && time < 25200f)
             if (light.intensity < 1f)
                  light.intensity += LightTransition;

        if (time > SecondsInDay)
            time = 0;
    }

}
