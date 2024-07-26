using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangoverMeter : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public int hangoverStartValue = 0;
    public int hangoverMax = 20;

    private void Start()
    {
        slider.maxValue = hangoverMax;
        slider.value = hangoverStartValue;
        

        fill.color = gradient.Evaluate(0f);
    }


    public void UpdateHangoverMeter(int hangoverHealth)
    {
        slider.value = hangoverHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
