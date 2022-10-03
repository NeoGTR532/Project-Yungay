using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public PlayerModel mb;
    public Image lifeBar;


    // Update is called once per frame
    void Update()
    {
        LifeUpdate();
    }
    public void LifeUpdate()
    {
        if (mb.health >= 0)
        {
            lifeBar.fillAmount = mb.health / mb.maxHealth;
        }
        else
        {
            Debug.Log("Tiezo");
        }


    }
}
