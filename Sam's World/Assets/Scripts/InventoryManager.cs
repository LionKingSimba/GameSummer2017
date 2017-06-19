using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

	GameObject InventoryUI;
	GameObject InventorySlotsPanel;
    ItemCatalog Catalog; //script
	public GameObject InventorySlot;
	public GameObject InventoryItem;

    private int numslots;

	public List<Item> ItemsList = new List<Item>();
	public List<GameObject> SlotsList = new List<GameObject>();
	
	void Start()
	{
        Catalog = GetComponent<ItemCatalog>(); //get the script from obj component

        numslots = 20;
		InventoryUI = GameObject.Find("InventoryUI");
		InventorySlotsPanel = InventoryUI.transform.FindChild("InventorySlots").gameObject;
		// InventorySlotsPanel = GameObject.Find("InventorySlots");
        
        //create slots for items in InventorySlotsPanel
        for (int i = 0; i < numslots; i++)
        {
            ItemsList.Add(new Item());
            SlotsList.Add(Instantiate(InventorySlot));
            SlotsList[i].transform.SetParent(InventorySlotsPanel.transform);
        }
	}

    //add item based on id passed in as arg.
    public void AddItem(int id)
    {
        Item ItemToAdd = Catalog.GetItembyID(id);
        for (int i = 0; i < ItemsList.Count; i++)
        {
            //if ID is -1, it is an empty item
            if (ItemsList[i].ID == -1)
            {
                ItemsList[i] = ItemToAdd;
                GameObject ItemObject = Instantiate(InventoryItem);
            }
        }
    }

}
