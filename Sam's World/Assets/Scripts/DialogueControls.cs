using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControls : MonoBehaviour
{

    public GameObject TextBox;
    public Text Text;
    public bool DialogueOn; //variable to see if talking is true or false
    public string[] DialogueArray;
    public int CurrentLine; //index number of dialogue line in the array
    
    private PlayerControls player;


	void Start ()
    {
        player = FindObjectOfType<PlayerControls>();
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
        //reset dialogue and player movement when talking is done
        if(CurrentLine >= DialogueArray.Length)
        {
            TextBox.SetActive(false);
            DialogueOn = false;
            CurrentLine = 0;
            player.CanMove = true;
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
        player.CanMove = false; //stop player from moving when talking
    }

}
