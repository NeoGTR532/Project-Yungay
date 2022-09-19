using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpLedge : MonoBehaviour
{
    public PlayerModel model;
    public bool detectLedge;
    public bool detectWall;
    public bool canUpLedge;
    [Range(0, 10)]
    public float maxDistance;
    public Transform head;
    public Transform body;
    public Transform target;
    public LayerMask climbableObject;
    private RaycastHit hit;
    private bool once = false;

    private void Update()
    {
        detectLedge = Physics.BoxCast(head.position, head.lossyScale / 2, head.forward, out hit, head.rotation, maxDistance, climbableObject);
        detectWall = Physics.BoxCast(body.position, body.lossyScale / 2, body.forward, out hit, body.rotation, maxDistance, climbableObject);

        if (!detectLedge && detectWall)
        {
            model.canUpLedge = true;
        }
        else
        {
            model.canUpLedge = false;
        }

        if (model.canUpLedge && !once)
        {
            once = true;
            StartCoroutine(ClimbLedge(transform.position, target.position));
        }
    }

    IEnumerator ClimbLedge(Vector3 start, Vector3 target)
    {
        float timer = 0;
        while (transform.position != target)
        {
            model.rb.useGravity = false;
            transform.position = Vector3.Lerp(start, target, timer / 1f);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = target;
        if (transform.position == target)
        {
            model.rb.useGravity = true;
            once = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        RaycastHit hit = this.hit;
        Gizmos.DrawWireCube(head.position + head.forward * hit.distance, head.lossyScale);
        Gizmos.DrawWireCube(body.position + body.forward * hit.distance, body.lossyScale);
    }
}
