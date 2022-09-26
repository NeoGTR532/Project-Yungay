using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image muteImage;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        CheckMute();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = sliderValue;
        CheckMute();
    }

    public void CheckMute()
    {
        if (sliderValue == 0)
        {
            muteImage.enabled = true;
        }
        else
        {
            muteImage.enabled = false;
        }
    }
}
