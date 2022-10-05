using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Drag drag = eventData.pointerDrag.GetComponent<Drag>();
            Vector3 pos = PlayerModel.playerTransform.position;
            pos.z+= 1;

            GameObject clone = Instantiate(drag.prefabItem, new Vector3(pos.x,pos.y,pos.z), Quaternion.identity);
        }
    }
}
