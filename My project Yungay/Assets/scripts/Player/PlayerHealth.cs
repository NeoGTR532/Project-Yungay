using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public PlayerModel mb;
    public Image lifeBar;
    float time;


    // Update is called once per frame
    void Update()
    {
        LifeUpdate();
        if (mb.armor > 0f)
        {
            mb.armor -= 1 * Time.deltaTime;
        }
    }
    public void Damage(float damage)
    {
        if (mb.health >= 0)
        {
            if (mb.armor > 0f)
            {
                mb.health -= damage / 2;
            }
            else
            {
                mb.health -= damage;
            }
        }
        else
        {
           // Debug.Log("Tiezo");
        }
    }
    public void LifeUpdate()
    {
        if (mb.health >= 0)
        {
            lifeBar.fillAmount = mb.health / mb.maxHealth;
        }
        if(mb.health<= 0)
        {
            time += 1 * Time.deltaTime;
            if (time >= 1)
            {
                mb.checkpoint.GetComponent<DataChekpoint>().ReturnPoint();
                time = 0;
            }
            Debug.Log("Tiezo");
            
        }
    }
}
