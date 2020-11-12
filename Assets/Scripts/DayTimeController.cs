using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    const float SecondsInDay = 86400f;
    float time;
    private int days;
    [SerializeField] Text TimeDisplay;
    [SerializeField] float TimeScale;

    void Start()
    {
        //Wczytywanie z pliku
    }

    private float getHours
    {
        get { return time / 3600f; }
    }

    private float getMinutes
    {
        get { return time % 3600f / 60f; }
    }

    void Update()
    {
        time += Time.deltaTime * TimeScale;
        int hours = (int)getHours + 7;
        int minutes = (int)getMinutes;
        TimeDisplay.text = hours.ToString("00") + ":" + minutes.ToString("00");
        
        if (time > SecondsInDay)
            NextDay();
    }

    private void NextDay()
    {
        time = 0;
        days += 1;
    }
}
