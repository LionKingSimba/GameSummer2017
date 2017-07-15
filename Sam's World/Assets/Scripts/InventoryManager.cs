using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

	GameObject InventoryUI; //inventory panel
	GameObject InventorySlotsPanel; //slot panel
    ItemCatalog Catalog; //script
	public GameObject InventorySlot;
	public GameObject InventoryItem;

    private int numslots;

	public List<Item> ItemsList = new List<Item>(); //list of all items
	public List<GameObject> SlotsList = new List<GameObject>(); //list of all slots
	
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
        AddItem(1);
        AddItem(1);
        AddItem(1);

        Debug.Log(ItemsList[0].Title);
	}

    //add item based on id passed in as arg.
    public void AddItem(int id)
    {
        Item ItemToAdd = Catalog.GetItembyID(id); //get item data

        //increase amount/stacks of item if item is stackable and exists in inventory
        if (ItemToAdd.Stackable && CheckInventoryforItem(ItemToAdd))
        {
            for (int i = 0; i < ItemsList.Count; i++)
            {
                if (ItemsList[i].ID == id)
                {
                    //get data from item if it exists
                    //recall child 0 of a slot is the ItemObject (instance of an InventoryItem of type GameObject)
                    ItemData data = SlotsList[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    //child 0 of data is the text indicating amount/stacks of the item
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        //else item is not stackable or does not exist in inventory
        else
        {
            //add single instance of item to inventory slot
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

    //check the inventory slot to see if the item exists
    bool CheckInventoryforItem(Item item)
    {
        //go through all the possible items
        for (int i = 0; i < ItemsList.Count; i++)
        {
            if (ItemsList[i].ID == item.ID)
            {
                return true;
            }
        }
        //if item was not found
        return false;
    }

}
