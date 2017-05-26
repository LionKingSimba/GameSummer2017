using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocation : MonoBehaviour {

    private PlayerControls sceneplayer;
    private CameraControls scenecamera;

    public Vector2 InitialDirection;

	// Use this for initialization
	void Start () {
        sceneplayer = FindObjectOfType<PlayerControls>();
        sceneplayer.transform.position = transform.position;
        sceneplayer.LastMove = InitialDirection;

        scenecamera = FindObjectOfType<CameraControls>();
        scenecamera.transform.position = new Vector3(transform.position.x, transform.position.y, scenecamera.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
