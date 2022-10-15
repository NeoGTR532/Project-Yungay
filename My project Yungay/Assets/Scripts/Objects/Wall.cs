using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int id;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.useLeverEvent += WallUp;
    }



    private void WallUp(int id)
    {
        if(id == this.id)
        {
            anim.SetBool("isUp", true);
        }
        
    }

    private void OnDisable()
    {
        EventManager.current.useLeverEvent -= WallUp;
    }
}
