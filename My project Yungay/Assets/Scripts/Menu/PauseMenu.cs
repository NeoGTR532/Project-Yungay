using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject panelOptions;
    public GameObject panelMenu;
    // Start is called before the first frame update
    void Start()
    {
        if (panelPause == null)
        {

        }

        if (panelOptions == null)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonOptions()
    {
        panelOptions.SetActive(true);
        panelPause.SetActive(false);
    }

    public void ButtonMenu()
    {
        panelPause.SetActive(false);
        panelMenu.SetActive(true);
        GameManager.inPause = false;
        SceneManager.LoadScene("Menu");
    }

    public void ButtonBack()
    {
        panelPause.SetActive(false);
        GameManager.inPause = false;
        Time.timeScale = 1F;
        GameManager.HideCursor();
    }
}
