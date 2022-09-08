using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacoBoxeo : MonoBehaviour
{
    public int life;


    public void RecibirDaño(int valor)
    {
        life -= valor;
    }
}
