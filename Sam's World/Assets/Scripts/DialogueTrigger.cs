using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public string dialogue;

    private DialogueControls dialoguecontroller;

	// Use this for initialization
	void Start () {
        dialoguecontroller = FindObjectOfType<DialogueControls>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D boxcolliderobj)
    {
        if(boxcolliderobj.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                dialoguecontroller.ShowBox(dialogue);
            }
        }
    }

}
