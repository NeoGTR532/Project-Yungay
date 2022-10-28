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
        CleanTexts();
    }
    public void TextHud(ItemObject itemObject, int cantidad)
    {
        testing = false;
        for (int i = 0; i < texto.Count; i++)
        {
            if(texto[i].text == "")
            {
                texto[i].text = "Recogido: " + itemObject.name + " (X" + cantidad.ToString() + ")";
                break;
            }
        }
        testing = true;
    }

    public void CleanTexts()
    {
        if (testing)
        {
            timer += Time.deltaTime;
        }

        if (timer >= maxTimer)
        {
            timer = 0f;
            for (int i = 0; i < texto.Count; i++)
            {
                if (texto[i].text != "")
                {
                    texto[i].text = "";
                }

            }
            testing = false;
        }
    }
}
