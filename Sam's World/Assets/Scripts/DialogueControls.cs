using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControls : MonoBehaviour {

    public GameObject TextBox;
    public Text Text;

    public bool DialogBoxOn;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(DialogBoxOn && Input.GetKeyDown(KeyCode.Space))
        {
            TextBox.SetActive(false);
            DialogBoxOn = false;
        }
	}

    public void ShowBox(string dialogue)
    {
        DialogBoxOn = true;
        TextBox.SetActive(true);
        Text.text = dialogue;
    }

}
