using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    public float MoveSpeed;

    private Vector2 minmovecoord;
    private Vector2 maxmovecoord;

    private Rigidbody2D NPCrigidbody;

    public bool IsMoving;
    public float MoveTime;
    public float WaitTime;

    private float movecounter;
    private float waitcounter;

    private int Direction;

    public Collider2D WalkArea;

    private bool haswalkarea;

	// Use this for initialization
	void Start () {
		NPCrigidbody = GetComponent<Rigidbody2D>();

        movecounter = MoveTime;
        waitcounter = WaitTime;

        ChooseDirection();

        if(WalkArea != null)
        {
            minmovecoord = WalkArea.bounds.min;
            maxmovecoord = WalkArea.bounds.max;
            haswalkarea = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(IsMoving)
        {
            movecounter -= Time.deltaTime; //move for MoveTime seconds
       
            //move in chosen direction
            switch(Direction)
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
        else
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
        Direction = Random.Range(0, 4);
        IsMoving = true;
        movecounter = MoveTime;
    }

}
