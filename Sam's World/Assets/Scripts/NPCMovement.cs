using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public bool IsMoving;
    public bool CanMove;
    public float MoveSpeed;
    public float MoveTime;
    public float WaitTime; //seconds between moving (stopped)
    public Collider2D WalkArea;

    private Rigidbody2D NPCrigidbody;
    private Vector2 minmovecoord; //bottom left of walk area
    private Vector2 maxmovecoord; //top right corner of walk area
    private float movecounter; //number of ticks to move
    private float waitcounter; //number of ticks to stop moving
    private int direction;
    private bool haswalkarea;
    private DialogueControls dialoguecontroller;

	
	void Start () {
		NPCrigidbody = GetComponent<Rigidbody2D>();
        dialoguecontroller = FindObjectOfType<DialogueControls>();

        movecounter = MoveTime;
        waitcounter = WaitTime;

        ChooseDirection();

        //bound NPC to walk area
        if(WalkArea != null)
        {
            minmovecoord = WalkArea.bounds.min;
            maxmovecoord = WalkArea.bounds.max;
            haswalkarea = true;
        }

        CanMove = true;
	}
	
	void Update () {
        //can move if not talking (no dialogue box)
        if(!dialoguecontroller.DialogueOn)
        {
            CanMove = true;
        }

        //stop moving if talking
        if (!CanMove)
        {
            NPCrigidbody.velocity = Vector2.zero;
            return;
        }

        //NPC movement logic
		if(IsMoving)
        {
            movecounter -= Time.deltaTime; //move for MoveTime seconds
       
            //move in chosen direction
            switch(direction)
            {
                case 0:
                    NPCrigidbody.velocity = new Vector2(0, MoveSpeed);
                    if(haswalkarea && transform.position.y > maxmovecoord.y)
                    {
                        IsMoving = false;
                        waitcounter = WaitTime;
                    }
                    break;

                case 1:
                    NPCrigidbody.velocity = new Vector2(MoveSpeed, 0);
                    if (haswalkarea && transform.position.x > maxmovecoord.x)
                    {
                        IsMoving = false;
                        waitcounter = WaitTime;
                    }
                    break;

                case 2:
                    NPCrigidbody.velocity = new Vector2(0, -MoveSpeed);
                    if (haswalkarea && transform.position.y < minmovecoord.y)
                    {
                        IsMoving = false;
                        waitcounter = WaitTime;
                    }
                    break;

                case 3:
                    NPCrigidbody.velocity = new Vector2(-MoveSpeed, 0);
                    if (haswalkarea && transform.position.x < minmovecoord.x)
                    {
                        IsMoving = false;
                        waitcounter = WaitTime;
                    }
                    break;
            }

            //stop moving if no moves left
            if (movecounter < 0)
            {
                IsMoving = false;
                waitcounter = WaitTime;
            }
        }
        else //stop moving and wait until counter hits 0
        {
            waitcounter -= Time.deltaTime;

            NPCrigidbody.velocity = Vector2.zero;

            if(waitcounter < 0)
            {
                ChooseDirection();
            }
        }
	}

    //use random int for direction
    //0=up, 1=right, 2=down, 3=left
    public void ChooseDirection()
    {
        direction = Random.Range(0, 4);
        IsMoving = true;
        movecounter = MoveTime;
    }

}
