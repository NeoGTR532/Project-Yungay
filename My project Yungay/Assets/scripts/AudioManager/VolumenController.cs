using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenController : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    [SerializeField]
    bool sliderGeneral, sliderSfx, sliderMusic;

    
    // Start is called before the first frame update
    void Start()
    {
        if (sliderGeneral)
        {
            AudioManager.Instance.ChangeMasterVolumen(slider.value);
            slider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeMasterVolumen(val));
        }
        /*
        if (sliderSfx)
        {
            AudioManager.Instance.ChangeVolumenSfx(slider.value);
            slider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeVolumenSfx(val));
        }

        if(sliderMusic)
        {
            AudioManager.Instance.ChangeVolumenMusic(slider.value);
            slider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeVolumenMusic(val));
        }
        */
    }
}
