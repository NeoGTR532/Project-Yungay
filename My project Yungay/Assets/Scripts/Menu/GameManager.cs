using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject panelOptions;
    private string sceneName;
    public static bool inPause = false;
    public bool inPase = false;
    public static string actualScene;

    public bool pause;
    //public static string actualScene;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        inPase = inPause;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (sceneName != "Menu" && inPause == false)
            {
                ShowCursor();

                Time.timeScale = 0f;
                panelPause.SetActive(true);
                inPause = true;
            }
            else if (sceneName != "Menu" && inPause && !panelOptions.activeSelf && !InventoryDisplay.isOpen)
            {
                HideCursor();
                Time.timeScale = 1f;
                panelPause.SetActive(false);
                inPause = false;
            }
            else if (sceneName != "Menu" && inPause && panelOptions.activeSelf)
            {
                panelOptions.SetActive(false);
                panelPause.SetActive(true);
            }

            if (sceneName == "Menu")
            {
                ShowCursor();
            }
            
        }

        actualScene = sceneName;

        pause = inPause;
    }


    public static void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public static void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
