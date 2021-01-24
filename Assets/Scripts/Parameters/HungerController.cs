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
    // Start is called before the first frame update
    void Start()
    {
        currentHunger = maxHunger;
    }

    // Update is called once per frame
    void Update()
    {
        hungerSlider.value = currentHunger;
        if(currentHunger < 50)
        {
            var fill = (hungerSlider as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>().FirstOrDefault(t => t.name == "Fill");
            Color orangeColor = new Color();
            fill.color = new Color(1f, 0.5f, 0f);
            if (currentHunger < 30)
                fill.color = Color.red;
        }
    }
}
