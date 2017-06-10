using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControls : MonoBehaviour
{

    public GameObject TextBox;
    public Text Text;

    public bool DialogueOn;

    public string[] DialogueArray;
    public int CurrentLine;
    

	void Start ()
    {
        
	}
	
	void Update ()
    {
        //close text box with spacebar
		if(DialogueOn && Input.GetKeyDown(KeyCode.Space))
        {
            //TextBox.SetActive(false);
            //DialogueOn = false;
            CurrentLine++;
        }
        //reset dialogue at end
        if(CurrentLine >= DialogueArray.Length)
        {
            TextBox.SetActive(false);
            DialogueOn = false;
            CurrentLine = 0;
        }
        //get current line of dialogue
        Text.text = DialogueArray[CurrentLine];
    }

    //old function to show dialogue using string arg
    public void ShowBox(string dialogue)
    {
        DialogueOn = true;
        TextBox.SetActive(true);
        Text.text = dialogue;
    }

    //function to show dialogue using line/index numbers
    public void ShowDialogue()
    {
        DialogueOn = true;
        TextBox.SetActive(true);
    }

}
