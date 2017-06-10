using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public string DialogueString;
    public string[] DialogueArray;

    private DialogueControls dialoguecontroller;


	
	void Start ()
    {
        dialoguecontroller = FindObjectOfType<DialogueControls>();
	}
	
	void Update ()
    {
		
	}

    void OnTriggerStay2D(Collider2D boxcolliderobj)
    {
        if(boxcolliderobj.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //dialoguecontroller.ShowBox(DialogueString);
                if(!dialoguecontroller.DialogueOn)
                {
                    dialoguecontroller.DialogueArray = DialogueArray;
                    dialoguecontroller.CurrentLine = 0;
                    dialoguecontroller.ShowDialogue();
                }
            }
        }
    }

}
