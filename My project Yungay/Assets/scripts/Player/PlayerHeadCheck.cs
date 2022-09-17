using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadCheck : MonoBehaviour
{
    public PlayerModel model;
    [Header("HeadCheck")]
    public float height;
    public bool headCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        headCheck = Physics.Raycast(transform.position, Vector3.up, height);
        
    }
}
