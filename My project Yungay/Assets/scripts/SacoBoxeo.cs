using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacoBoxeo : MonoBehaviour
{
    public int life;


    public void RecibirDaņo(int valor)
    {
        life -= valor;
    }
}
