using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class TemperatureController : MonoBehaviour
{
    public Slider temperatureSlider;
    public float maxTemperature;
    public static float currentTemperature;
    // Start is called before the first frame update
    void Start()
    {
        currentTemperature = maxTemperature;
    }

    // Update is called once per frame
    void Update()
    {
        temperatureSlider.value = currentTemperature;
        if (currentTemperature < 50)
        {
            var fill = (temperatureSlider as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>().FirstOrDefault(t => t.name == "Fill");
            Color orangeColor = new Color();
            fill.color = new Color(1f, 0.5f, 0f);
            if (currentTemperature < 30)
                fill.color = Color.red;
        }
    }
}
