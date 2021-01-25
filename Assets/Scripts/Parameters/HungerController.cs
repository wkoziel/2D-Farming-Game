using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HungerController : MonoBehaviour
{
    public Slider hungerSlider;
    public float maxHunger;
    public static float currentHunger;
    public Image fillSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHunger = maxHunger;
        fillSlider = (hungerSlider as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>().FirstOrDefault(t => t.name == "Fill");

    }

    // Update is called once per frame
    void Update()
    {
        hungerSlider.value = currentHunger;
        if (currentHunger >= 50)
            fillSlider.color = Color.green;
        else if (currentHunger < 50 && currentHunger >= 30)
        {
            Color orangeColor = new Color();
            fillSlider.color = new Color(1f, 0.5f, 0f);
        }
        else if (currentHunger < 30)
            fillSlider.color = Color.red;
    }
}
