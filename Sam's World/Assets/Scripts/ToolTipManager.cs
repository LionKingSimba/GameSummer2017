﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipManager : MonoBehaviour {

    private Item item;
    private string itemname;
    private GameObject tooltip;

    void Start()
    {
        tooltip = GameObject.Find("ToolTip");
        tooltip.SetActive(false);
    }

    //show tooltip when mouse hovers over item
    public void ToolTipOn(Item item)
    {
        this.item = item;
        ConstructString();
        tooltip.SetActive(true);
    }

    //turn off tooltip when mouse is not over an item
    public void ToolTipOff()
    {

    }

    //create string that contains tooltip information
    //does text concaternation and styling
    public void ConstructString()
    {
        itemname = item.Title;
    }

}
