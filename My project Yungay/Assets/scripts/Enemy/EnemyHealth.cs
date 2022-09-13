using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int life;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void lifeE(int valor)
    {
        life-=valor;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
