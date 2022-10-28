using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicTutorial : MonoBehaviour
{
    private PlayableDirector director;
    public Camera cinematicCamera;
    public Camera playerCamera;


    //public GameObject controlPanel;

    // Start is called before the first frame update
    void Awake()
    {
        director = GetComponent<PlayableDirector>();
        //director.played += Director_Played;
        director.stopped += EndTimeline;
    }

    private void Start()
    {
        StarTimeline();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //private void Director_Played(PlayableDirector obj)
    //{
    //    controlPanel.SetActive(false);
    //}

    //private void Director_Stopped(PlayableDirector obj)
    //{
    //    controlPanel.SetActive(true);
    //}

    public void StarTimeline()
    {
        GameManager.inPause = true;
        cinematicCamera.targetDisplay = 0;
        playerCamera.targetDisplay = 1;
        director.Play();
       
    }

    public void EndTimeline(PlayableDirector obj)
    {
        cinematicCamera.targetDisplay = 1;
        playerCamera.targetDisplay = 0;
        GameManager.inPause = false;
    }
}
