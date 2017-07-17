using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems; //for inventory ui

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Item item;
    public int amount;

    private Transform origparent;
    private Vector2 offset; //difference in position of icon and mouse

    //interface implementation for IBeginDragHandler
    public void OnBeginDrag(PointerEventData eventData)
    {
        //allow dragging (within the slot) if item exists
        if (item != null)
        {
            //offset = mouse position - icon position
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
            origparent = this.transform.parent; //original parent is InventorySlot
            //need to set parent outside of InventorySlot since item is dragged outside of InventorySlot
            this.transform.SetParent(this.transform.parent.parent); //set item parent to be InventorySlotsPanel (parent of InventorySlot)
            this.transform.position = eventData.position; //set item position to cursor position
        }
    }

    //interface implementation for IDragHandler
    public void OnDrag(PointerEventData eventData)
    {
        //allow items to be dragged outside of slot
        if (item != null)
        {
            this.transform.position = eventData.position - offset; //set item position to cursor position
        }
    }

    //interface implementation for IEndDragHandler
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(origparent); //set item parent to be slot again
    }
}
