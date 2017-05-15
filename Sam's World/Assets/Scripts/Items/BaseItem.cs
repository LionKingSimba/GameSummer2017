using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseItem
{

    private string itemname;
    private string itemdescription;
    private int itemid;

    public enum ItemTypes
    {
        EQUIPMENT,
        CONSUMABLES,
        QUEST,
        OTHER
    }

    private ItemTypes itemtype;

    public string ItemName
    {
        get { return itemname; }
        set { itemname = value; }
    }

    public string ItemDescription
    {
        get { return itemdescription; }
        set { itemdescription = value; }
    }

    public int ItemID
    {
        get { return itemid; }
        set { itemid = value; }
    }

    public ItemTypes ItemType
    {
        get { return itemtype; }
        set { itemtype = value; }
    }

}
