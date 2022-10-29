using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public int leverID;
    public int id;
    public Animator anim;
    public Animator fade;

    private void Start()
    {
        EventManager.current.useLeverEvent += StartCinematic;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            EventManager.current.StartUseLeverEvent(leverID);
            anim.SetBool("isUse", true);

        }
    }


    private void StartCinematic(int id)
    {
        if (id == this.id)
        {
            Debug.Log("Inicia la cinematica");
            StartCoroutine(Fading());
            
        }

    }

    private void OnDisable()
    {
        EventManager.current.useLeverEvent -= StartCinematic;
    }


    IEnumerator Fading()
    {
        fade.SetBool("isFade", true);
        yield return new WaitForSeconds(3f);
        fade.SetBool("isFade", false);
    }

    public void TravelSound()
    {
        AudioManager.Instance.PlaySFX("Car");
    }
}
