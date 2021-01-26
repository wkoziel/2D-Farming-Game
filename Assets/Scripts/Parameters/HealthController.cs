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
    public Image fillSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        fillSlider = (healthSlider as UnityEngine.UI.Slider).GetComponentsInChildren<UnityEngine.UI.Image>().FirstOrDefault(t => t.name == "Fill");

    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;
        if (currentHealth >= 50)
            fillSlider.color = Color.green;
        else if (currentHealth < 50 && currentHealth >= 30)
        {
            Color orangeColor = new Color();
            fillSlider.color = new Color(1f, 0.5f, 0f);
        }
        else if (currentHealth < 30)
            fillSlider.color = Color.red;
    }

}
