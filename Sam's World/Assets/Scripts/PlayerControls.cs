using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public float MoveSpeed;

    private Animator player;
    private bool playermoving;
    private Vector2 lastmove;

	// initialization
	void Start ()
    {
        player = GetComponent<Animator>();
	}
	
	// Update called once per frame
	void Update ()
    {
        playermoving = false;

	    if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime, 0f, 0f));
            playermoving = true;
            lastmove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime, 0f));
            playermoving = true;
            lastmove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        player.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        player.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        player.SetBool("PlayerMoving", playermoving);
        player.SetFloat("LastMoveX", lastmove.x);
        player.SetFloat("LastMoveY", lastmove.y);
    }

}
