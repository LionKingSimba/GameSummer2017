using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems; //for inventory ui

/*
script to enable movement of items from slot to slot (InventorySlot) in slot panel (InventorySlots)
note InventorySlot (single slot) != InventorySlots (multiple slots)
*/
public class ItemData : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Item item;
    public int amount;
    public int slotid; //each slot has an id for its location
    
    private InventoryManager inventory;
    private Vector2 offset; //difference in position of icon and mouse
    private Boolean enableoffset = true; //set true if you want to enable offset

    void Start()
    {
        inventory = GameObject.Find("TestInventory").GetComponent<InventoryManager>(); //!!! test
        //inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>(); //use this for REAL inventory
    }

    //interface implementation for IPointerDownHandler
    public void OnPointerDown(PointerEventData eventData)
    {
        offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        this.transform.position = eventData.position - offset;
    }

    //interface implementation for IBeginDragHandler
    public void OnBeginDrag(PointerEventData eventData)
    {
        //allow dragging (within the slot) if item exists
        if (item != null)
        {
            //offset = mouse position - icon position
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
            
            //need to set parent outside of InventorySlot since item is dragged outside of InventorySlot
            this.transform.SetParent(this.transform.parent.parent); //set item parent to be InventorySlotsPanel (parent of InventorySlot)
            this.transform.position = eventData.position; //set item position to cursor position
            GetComponent<CanvasGroup>().blocksRaycasts = false; //stop blocking raycast after item is in "drag" mode
        }
    }

    //interface implementation for IDragHandler
    public void OnDrag(PointerEventData eventData)
    {
        //allow items to be dragged outside of slot
        if (item != null)
        {
            if (enableoffset)
            {
                this.transform.position = eventData.position - offset; //set item position to cursor position
            }
            else
            {
                this.transform.position = eventData.position; //set item position to cursor position
            }
        }
    }

    //interface implementation for IEndDragHandler
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(inventory.SlotsList[slotid].transform); //set item parent to be slot again
        this.transform.position = inventory.SlotsList[slotid].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true; //start blocking raycast after item is in "dropped" mode
    }

}
