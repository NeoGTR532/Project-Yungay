using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSimple : MonoBehaviour
{
    public int cubo1 = 0;
    public int cubo2 = 0;
    public int cubo4 = 0;
    public GameObject cuboverde;
    public GameObject cubonaranja;
    public GameObject position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            CraftingVerde();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            CraftingNaranja();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cubo1")
        {
            cubo1 += 1;  
        }

        if (other.gameObject.tag == "cubo2")
        {
            cubo2 += 1;
        }

        if(other.gameObject.tag == "cubo4")
        {
            cubo4 += 1;
        }

    }
    void CraftingVerde()
    {
        if(cubo1>=1 && cubo2>=1)
        {
            Instantiate(cuboverde, position.transform.position, Quaternion.identity);
            cubo1 -= 1;
            cubo2 -= 1;
        }

        


    }
    void CraftingNaranja()
    {
        if (cubo1 >= 1 && cubo4 >= 1)
        {
            Instantiate(cubonaranja, position.transform.position, Quaternion.identity);
            cubo1 -= 1;
            cubo4 -= 1;
        }
    }
}
