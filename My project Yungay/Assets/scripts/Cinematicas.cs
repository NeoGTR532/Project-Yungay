using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematicas : MonoBehaviour
{
    public GameObject cam;
    public GameObject camCine;
    public List<PositionSingle> position = new List<PositionSingle>();
    private string tagP = "PositionCine";

    private void Awake()
    {
       /* Transform Targets = transform.Find("Position");

        foreach(Transform PositionSingle in Targets)
        {
            Debug.Log(PositionSingle);
        }*/
    }
    public void CreatePosition()
    {
        GameObject targets = new("Position");
        targets.AddComponent<Draw>();
        position.Add(new PositionSingle(targets));
        targets.tag = tagP;
    }
    [System.Serializable]
    public class PositionSingle
    {
        public GameObject position;

        public PositionSingle(GameObject position)
        {
            this.position = position;
        }
    }
}