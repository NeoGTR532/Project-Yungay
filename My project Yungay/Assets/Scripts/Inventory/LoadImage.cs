using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LoadImage : MonoBehaviour
{
    private Image imageChild;
    private CraftDisplay craft;
    private Coroutine coroutine;
    
    
    // Start is called before the first frame update
    void Start()
    {
        imageChild = transform.GetChild(0).GetComponent<Image>();
        imageChild.fillAmount = 0f;
        craft = GetComponent<CraftDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void ClickImage()
    //{
    //    if (craft.canCraft)
    //    {
    //        coroutine = StartCoroutine(ChargeImage());
    //    }
    //}

    public void UpClick()
    {
        StopCoroutine(coroutine);
        imageChild.fillAmount = 0f;
    }

    public IEnumerator ChargeImage()
    {
        while (imageChild.fillAmount < 1f) {
            imageChild.fillAmount += 0.1f;
            yield return null;
        }

        imageChild.fillAmount = 1f;
        //craft.inventory.CraftItem(craft.recipe);
        //craft.inventory.UpdateInventory();
        //craft.inventoryDisplay.UpdateDisplay();
        //craft.CheckIsCraftable();
    }
}
