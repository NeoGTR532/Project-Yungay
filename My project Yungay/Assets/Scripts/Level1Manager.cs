using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public bool start;
    public static bool isTravel = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLv1());
    }

    // Update is called once per frame
    void Update()
    {
        if(!start)
        {
            MisionText.currentMision = 0;
        }

        else
        {
            MisionText.currentMision = 1;

            if (isTravel == true)
            {
                MisionText.currentMision = 2;
            }
        }
        
      
    }

    IEnumerator StartLv1()
    {
        yield return new WaitForSeconds(2f);

        start = true;


    }
}
