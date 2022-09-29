using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panelMainMenu;
    public GameObject panelOptions;
    private void Awake()
    {
        //panelMainMenu = GameObject.Find("Panel MainMenu");
        if(panelMainMenu == null)
        {

        }


        if (panelOptions == null)
        {

        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (panelMainMenu.activeSelf)
        {
            Time.timeScale = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ButtonStart()
    {
        panelMainMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Player Movement Scene");
    }

    public void ButtonOptions()
    {
        panelMainMenu.SetActive(false);
        panelOptions.SetActive(true);
    }

    public void ButtonCredits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void ButtonExitGame()
    {
        Application.Quit();
    }
}
