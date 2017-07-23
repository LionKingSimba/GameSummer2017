using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LitJson;
using System.IO;

//component of TestInventory
//script to manage item data
public class ItemCatalog : MonoBehaviour
{

    private List<Item> catalog = new List<Item>();
    private JsonData itemdata;

    void Start()
    {
        //get itemdata from the Items.json file
        itemdata = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemCatalog();

        //test code
        //Debug.Log(catalog[1].Title);
        //Debug.Log(GetItembyID(0).Description);
        Debug.Log(GetItembyID(0).SpriteName);
    }

    //search for an item by its id
    public Item GetItembyID(int id)
    {
        for (int i = 0; i < catalog.Count; i++)
        {
            if (catalog[i].ID == id)
            {
                return catalog[i];
            }
        }
        return null; //item not found  
    }

    //build the item catalog using the itemdata variable created from the Items.json file
    void ConstructItemCatalog()
    {
        for (int i = 0; i < itemdata.Count; i++)
        {
            catalog.Add(new Item(
                (int) itemdata[i]["id"], itemdata[i]["title"].ToString(), (int) itemdata[i]["value"],
                (int) itemdata[i]["stats"]["str"], (int) itemdata[i]["stats"]["agi"], (int) itemdata[i]["stats"]["int"],
                itemdata[i]["description"].ToString(), (bool) itemdata[i]["stackable"], (int) itemdata[i]["rarity"],
                itemdata[i]["spritename"].ToString()
                ));
        }
    }

}


//item class (currently 9 variables/properties per object)
public class Item
{
    public int ID { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intelligence { get; set; }

    public int Value { get; set; }
    public int Rarity { get; set; }
    public bool Stackable { get; set; }
    
    public string SpriteName { get; set; }
    public Sprite Sprite { get; set; }

    //detailed item constructor
    public Item(int ID, string Title, string Type, string Description, int Strength, int Agility, int Intelligence, int Value, int Rarity, bool Stackable, string SpriteName)
    {
        this.ID = ID;
        this.Title = Title;
        this.Type = Type;
        this.Description = Description;

        this.Strength = Strength;
        this.Agility = Agility;
        this.Intelligence = Intelligence;

        this.Value = Value;
        this.Stackable = Stackable;
        this.Rarity = Rarity;

        this.SpriteName = SpriteName;
        this.Sprite = Resources.Load<Sprite>("Art/Items/" + SpriteName);
    }

    //simple item constructor
    public Item(int ID, string Title, int Value)
    {
        this.ID = ID;
        this.Title = Title;
        this.Value = Value;
    }

    //empty item for deletions or error checking
    public Item()
    {
        this.ID = -1;
    }
}
