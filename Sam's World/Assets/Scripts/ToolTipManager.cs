using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ToolTipManager : MonoBehaviour {

    private Item item;
    private string itemname;
    private GameObject tooltip;

    void Start()
    {
        tooltip = GameObject.Find("ToolTip");
        tooltip.SetActive(false);
    }

    //adjust tooltip position with mouse position
    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }    
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
        tooltip.SetActive(false);
    }

    //create string that contains tooltip information based on item type
    //does text concaternation and styling
    //Note item type will affect the tooltip display
    public void ConstructString()
    {
        if (item.Type == "Equipment")
        {
            itemname = "<color=#00ffff><b>" + item.Title + "</b></color>" + "\n\n"
                        + item.Description + "\n\n"
                        + "<color=#ffff00>" + "Value: " + item.Value + "</color>";
        }
        else
        {
            itemname = "<color=#00ffff><b>" + item.Title + "</b></color>" + "\n\n"
                        + item.Description + "\n\n"
                        + "<color=#ffff00>" + "Value: " + item.Value + "</color>";
        }
        tooltip.transform.GetChild(0).GetComponent<Text>().text = itemname; //child of ToolTip is Text
    }

}
