using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void TakeDamage(float damage)
    {

        slider.value -= damage;

    }

    public void LoadHealth(float health)
    {
        slider.value = health;
    }

}
