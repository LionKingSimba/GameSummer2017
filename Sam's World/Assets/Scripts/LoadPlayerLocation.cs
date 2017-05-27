using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerLocation : MonoBehaviour
{

    private PlayerControls sceneplayer;
    private CameraControls scenecamera;

    public Vector2 InitialDirection;

    public string LocationName;

	// Use this for initialization
	void Start ()
    {
        sceneplayer = FindObjectOfType<PlayerControls>();

        //move player and camera to location in current scene with same name as the location that player entered in past scene
        if (sceneplayer.EntryLocationName == LocationName)
        {
            sceneplayer.transform.position = transform.position;
            sceneplayer.LastMove = InitialDirection;

            scenecamera = FindObjectOfType<CameraControls>();
            scenecamera.transform.position = new Vector3(transform.position.x, transform.position.y, scenecamera.transform.position.z);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
