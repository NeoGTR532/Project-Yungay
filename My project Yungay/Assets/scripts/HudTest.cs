using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudTest : MonoBehaviour
{
    public List<TMP_Text> texto = new ();
    public bool testing;
    public float timer;
    public float maxTimer;

    private void Update()
    {
        if(testing)
        {
            timer += Time.deltaTime;
        }
        if(timer >= maxTimer)
        {
            timer = 0; 
            for (int i = 0; i < texto.Count; i++)
            {
                if (texto[i].text != "")
                {
                    texto[i].text = "";
                }

            }
        }
    }
    public void TextHud(ItemObject itemObject, int cantidad)
    {
        for (int i = 0; i < texto.Count; i++)
        {
            if(texto[i].text == "")
            {
                texto[i].text = "Recogido: " + itemObject.name + " (X" + cantidad.ToString() + ")";
            }
            break;
        }
        testing = true;
    }
}
