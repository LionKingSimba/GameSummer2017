using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

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

        numslots = 21;
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

        AddItem(0);

        Debug.Log(ItemsList[0].Title);
	}

    //add item based on id passed in as arg.
    public void AddItem(int id)
    {
        Item ItemToAdd = Catalog.GetItembyID(id); //get item data
        for (int i = 0; i < ItemsList.Count; i++)
        {
            //if ID is -1, it is an empty item
            if (ItemsList[i].ID == -1)
            {
                ItemsList[i] = ItemToAdd; //put item in list
                GameObject ItemObject = Instantiate(InventoryItem); //create item
                ItemObject.transform.SetParent(SlotsList[i].transform); //create slot
                ItemObject.transform.position = Vector2.zero;
                ItemObject.GetComponent<Image>().sprite = ItemToAdd.Sprite; //item image
                ItemObject.name = ItemToAdd.Title; //give item title in inspector
                break;
            }
        }
    }

}
