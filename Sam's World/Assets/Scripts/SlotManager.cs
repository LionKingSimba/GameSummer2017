using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

/*
script to handle InventorySlot (individual slots)
(not InventorySlots, which is the slots panel)

this script handles new slots
*/
public class SlotManager : MonoBehaviour, IDropHandler
{

    public int id; //id of new slot

	private InventoryManager inventory;

	void Start()
	{
		inventory = GameObject.Find("TestInventory").GetComponent<InventoryManager>(); //!!! test
        //inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>(); //use this for REAL inventory
	}

	//interface implementation for IDropHandler
	public void OnDrop(PointerEventData eventData)
	{
		ItemData droppeditem = eventData.pointerDrag.GetComponent<ItemData>(); //get the item placed in the slot
        //if slot is empty, set slot as item parent
        if (inventory.ItemsList[id].ID == -1)
        {
            inventory.ItemsList[droppeditem.slotid] = new Item(); //null out old slot
            inventory.ItemsList[id] = droppeditem.item; //set the new item in the list of items
            droppeditem.slotid = id;
        }
        //if slot is not empty, swap item slots
        /*
        need to check if item is not dropped in same place
        when dropping items on same spot, script becomes confused
        since clicking/dragging an item removes it from its slot
        then the slot has no child (thus this.transform.GetChild(0) gives an error)
        */
        else if (droppeditem.slotid != id) 
        {
            //move the item in the new slot to the old slot
            Transform itemtoswap = this.transform.GetChild(0); //first child of slot is the item
            itemtoswap.GetComponent<ItemData>().slotid = droppeditem.slotid; //set old slot id for item
            itemtoswap.transform.SetParent(inventory.SlotsList[droppeditem.slotid].transform); //set old slot as item parent
            itemtoswap.transform.position = inventory.SlotsList[droppeditem.slotid].transform.position;

            //move the selected/held item to the new slot
            droppeditem.slotid = id;
            droppeditem.transform.SetParent(this.transform); //set new slot as item parent
            droppeditem.transform.position = this.transform.position;

            //update the swap for slots
            inventory.ItemsList[droppeditem.slotid] = itemtoswap.GetComponent<ItemData>().item; //for swapped item
            inventory.ItemsList[id] = droppeditem.item; //for held item
        }
	}

}
