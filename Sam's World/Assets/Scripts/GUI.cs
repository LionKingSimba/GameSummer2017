using UnityEngine;
using System.Collections;


public class GUI
{

    private BaseClass fighter = new BaseFighterClass();
    private BaseClass rogue = new BaseRogueClass();
    private BaseClass mage = new BaseMageClass();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUILayout.Label(fighter.ClassName);
        GUILayout.Label(fighter.ClassDescription);
        GUILayout.Label(rogue.ClassName);
        GUILayout.Label(rogue.ClassDescription);
        GUILayout.Label(mage.ClassName);
        GUILayout.Label(mage.ClassDescription);
    }

}
