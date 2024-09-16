using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public BossHealth bossHealth;
    public Slider slider;

    void Start()
    {
        slider.maxValue = bossHealth.health;
    }

    
    void Update()
    {
        slider.value = bossHealth.health;
    }
}
