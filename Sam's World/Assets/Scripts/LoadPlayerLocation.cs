using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerLocation : MonoBehaviour
{

    public string LocationName; //player's current location in the loaded scene
    public Vector2 InitialDirection;

    private PlayerControls sceneplayer;
    private CameraControls scenecamera;

	
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

	void Update ()
    {
		
	}
}
