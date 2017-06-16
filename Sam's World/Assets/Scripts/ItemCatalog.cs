using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LitJson;
using System.IO;

public class ItemCatalog : MonoBehaviour
{

    private List<Item> catalog = new List<Item>();
    private JsonData itemdata;

    void Start()
    {
        itemdata = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemCatalog();

        Debug.Log(catalog[1].Title);
    }

    void ConstructItemCatalog()
    {
        for (int i = 0; i < itemdata.Count; i++)
        {
            catalog.Add(new Item( (int) itemdata[i]["id"], itemdata[i]["title"].ToString(), (int) itemdata[i]["value"] ));
        }
    }

}

public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }

    public Item(int ID, string Title, int Value)
    {
        this.ID = ID;
        this.Title = Title;
        this.Value = Value;
    }
}
