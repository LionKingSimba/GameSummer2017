using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

//script to handle InventorySlot (individual slots)
//(not InventorySlots, which is the slots panel)
public class SlotManager : MonoBehaviour, IDropHandler
{

    public int id; //id of slot

	private InventoryManager inventory;

	private void Start()
	{
		inventory = GameObject.Find("InventoryUI").GetComponent<InventoryManager>();
	}

	//interface implementation for IDropHandler
	public void OnDrop(PointerEventData eventData)
	{
		ItemData droppeditem = eventData.pointerDrag.GetComponent<ItemData>(); //get the item placed in the slot
        //if slot is empty, set slot as item parent
        if (inventory.ItemsList[id].ID == -1)
        {
            droppeditem.transform.SetParent(this.transform);
            droppeditem.transform.position = this.transform.position;
        }
	}

}
