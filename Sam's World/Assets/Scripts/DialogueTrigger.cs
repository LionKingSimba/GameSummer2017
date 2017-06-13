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

    //if player presses space near current object, turn on dialogue
    void OnTriggerStay2D(Collider2D boxcolliderobj)
    {
        if(boxcolliderobj.gameObject.name == "Player")
        {
            if (dialoguecontroller.DialogueOn == false && Input.GetKeyUp(KeyCode.Space))
            {
                //dialoguecontroller.ShowBox(DialogueString);
                if(!dialoguecontroller.DialogueOn)
                {
                    dialoguecontroller.DialogueArray = DialogueArray;
                    dialoguecontroller.CurrentLine = 0;
                    dialoguecontroller.ShowDialogue();
                }
                if(transform.parent.GetComponent<NPCMovement>() != null) //true if parent of object with this script has an NPCMovement script
                {
                    transform.parent.GetComponent<NPCMovement>().CanMove = false;
                }
            }
        }
    }

}
