using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class HealthController : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth;
    public static float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;
        if (currentHealth < 50)
        {
            var fill = (healthSlider as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>().FirstOrDefault(t => t.name == "Fill");
            Color orangeColor = new Color();
            fill.color = new Color(1f, 0.5f, 0f);
            if (currentHealth < 30)
                fill.color = Color.red;
        }
    }
}
