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
        if (mb.armor > 0f)
        {
            mb.armor -= 1 * Time.deltaTime;
        }
    }
    public void Damage(float damage)
    {
        if (mb.health > 0)
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
            Debug.Log("Tiezo");
        }
    }
    public void LifeUpdate()
    {
        if (mb.health >= 0)
        {
            lifeBar.fillAmount = mb.health / mb.maxHealth;
        }
        else
        {
            mb.checkpoint.GetComponent<DataChekpoint>().FixEnemy();
            mb.health = mb.maxHealth;
            //Debug.Log("Tiezo");
        }
    }
}
