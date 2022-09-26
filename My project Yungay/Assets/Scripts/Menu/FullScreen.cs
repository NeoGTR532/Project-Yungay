using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;

    public TMP_Dropdown resolutionsDropdown;
    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }

        else
        {
            toggle.isOn = false;
        }

        CheckResolution();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void CheckResolution()
    {
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();
        List<string> options = new List<string>();
        int resolutionActual = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resolutionActual = i;
            }
        }

        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = resolutionActual;
        resolutionsDropdown.RefreshShownValue();

        resolutionsDropdown.value = PlayerPrefs.GetInt("numberResolution", 0);
    }

    public void ChangeResolution(int indexResolution)
    {
        PlayerPrefs.SetInt("numberResolution", resolutionsDropdown.value);

        Resolution resolution = resolutions[indexResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
