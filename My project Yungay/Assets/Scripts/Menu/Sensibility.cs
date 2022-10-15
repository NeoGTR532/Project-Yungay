using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sensibility : MonoBehaviour
{
    public Slider slider;
    public float slidervalue;
    public TMP_Text textValue;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Sensibility", 125f);
        PlayerCam.sensX = slider.value;
        PlayerCam.sensY = slider.value;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSlider(float value)
    {
        slidervalue = value;
        PlayerPrefs.SetFloat("Sensibility", slidervalue);
        PlayerCam.sensX = slider.value;
        PlayerCam.sensY = slider.value;
        ShowValue();

    }

    public void ShowValue()
    {
        float distanceFromMin = (slider.value - slider.minValue);
        float sliderRange = (slider.maxValue - slider.minValue);
        float sliderPercent = (distanceFromMin / sliderRange);
        textValue.text = sliderPercent.ToString("F2");
    }
}
