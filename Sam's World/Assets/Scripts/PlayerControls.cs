﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public string EntryLocationName; //where player entered scene

    public float MoveSpeed;
    public float DiagonalMoveModifier;
    public Vector2 LastMove;
    public bool CanMove;

    private static bool playerinscene; //to ensure number of players in scene is 1
    private bool playermoving;
    private Animator player;
    private Rigidbody2D playerrigidbody;
    private float currentmovespeed;
    
	
	void Start ()
    {
        player = GetComponent<Animator>();
        playerrigidbody = GetComponent<Rigidbody2D>();
        CanMove = true;

        //if new scene has no player, keep the past scene player
        if (!playerinscene)
        {
            playerinscene = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        //if new scene already has player, destroy the latest (duplicate) player
        else
        {
            Destroy(gameObject);
        }
	}
	
	void Update ()
    {
        playermoving = false;

        if(!CanMove)
        {
            playerrigidbody.velocity = Vector2.zero;
            return;
        }

        //horizontal movement
	    if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime, 0f, 0f));
            playerrigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentmovespeed, playerrigidbody.velocity.y);
            playermoving = true;
            LastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        //vertical movement
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime, 0f));
            playerrigidbody.velocity = new Vector2(playerrigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentmovespeed);
            playermoving = true;
            LastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        //stop horizontal movement
        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            playerrigidbody.velocity = new Vector2(0f, playerrigidbody.velocity.y);
        }

        //stop vertical movement
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            playerrigidbody.velocity = new Vector2(playerrigidbody.velocity.x, 0f);
        }

        //diagonal movespeed
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            currentmovespeed = MoveSpeed * DiagonalMoveModifier;
        }
        else
        {
            currentmovespeed = MoveSpeed;
        }

        player.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        player.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        player.SetBool("PlayerMoving", playermoving);
        player.SetFloat("LastMoveX", LastMove.x);
        player.SetFloat("LastMoveY", LastMove.y);
    }

}
