using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems; //for inventory ui

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Item item;
    public int amount;

    //interface implementation for IBeginDragHandler
    public void OnBeginDrag(PointerEventData eventData)
    {
        //allow dragging if item exists
        if (item != null)
        {
            this.transform.position = eventData.position;
        }
    }

    //interface implementation for IDragHandler
    public void OnDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    //interface implementation for IEndDragHandler
    public void OnEndDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
