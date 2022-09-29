using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelPause;
    private string sceneName;
    public static bool inPause = false;
    public static string actualScene;
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
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(sceneName != "Menu" && inPause == false)
            {
                ShowCursor();

                Time.timeScale = 0f;
                panelPause.SetActive(true);
                inPause = true;
            }
            else
            {
                HideCursor();
                Time.timeScale = 1f;
                panelPause.SetActive(false);
                inPause = false;
            }
        }

        actualScene = sceneName;
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
