using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

	GameObject InventoryUI;
	GameObject InventorySlotsPanel;
	public GameObject InventorySlot;
	public GameObject InventoryItem;

    int numslots;
	public List<Item> Items = new List<Item>();
	public List<GameObject> Slots = new List<GameObject>();
	
	void Start()
	{
        numslots = 20;
		InventoryUI = GameObject.Find("InventoryUI");
		InventorySlotsPanel = InventoryUI.transform.FindChild("InventorySlots").gameObject;
		// InventorySlotsPanel = GameObject.Find("InventorySlots");
        
        //create slots for items in InventorySlotsPanel
        for (int i = 0; i < numslots; i++)
        {
            Slots.Add(Instantiate(InventorySlot));
            Slots[i].transform.SetParent(InventorySlotsPanel.transform);
        }
	}

}
