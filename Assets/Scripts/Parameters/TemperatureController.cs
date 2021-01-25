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
    public Image fillSlider;
    // Start is called before the first frame update
    void Start()
    {
        currentTemperature = maxTemperature;
        fillSlider = (temperatureSlider as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>().FirstOrDefault(t => t.name == "Fill");
    }

    // Update is called once per frame
    void Update()
    {
        temperatureSlider.value = currentTemperature;
        if (currentTemperature >=50 )
            fillSlider.color = Color.green;
        else if (currentTemperature < 50 && currentTemperature >= 30)
        {
            Color orangeColor = new Color();
            fillSlider.color = new Color(1f, 0.5f, 0f);
        }
        else if (currentTemperature < 30)
            fillSlider.color = Color.red;
        
    }
}
