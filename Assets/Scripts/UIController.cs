using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //can barýný kullanmak için kullandýðýmýz script
    public Slider slider;
    public Slider easeSlider;
    HealthController healthController;
    private float lerpSpeed = 0.01f;
    void Start()
    {
        healthController = GetComponent<HealthController>();
    }

    
    void Update()
    {
        SetHealth();
        if (slider.value != healthController.health)
        {
            slider.value = healthController.health; 
        }

        if (slider.value != easeSlider.value)
        {

            easeSlider.value = Mathf.Lerp(easeSlider.value, healthController.health, lerpSpeed);
        }
    }
    public void SetMaxHealth()
    {
        slider.maxValue = healthController.health;
        slider.value = healthController.health;
    }
    public void SetHealth()
    {
        slider.value = healthController.health;
    }
}
