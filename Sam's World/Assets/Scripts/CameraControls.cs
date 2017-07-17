using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to manage Main Camera
public class CameraControls : MonoBehaviour
{

    public GameObject FollowTarget; //object that camera follows
    public float CameraSpeed;

    private static bool camerainscene; //to ensure number of cameras in scene is 1
    private Vector3 targetposition;

	
	void Start ()
    {
        //if new scene has no camera, keep the past scene camera
        if (!camerainscene)
        {
            camerainscene = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        //if new scene already has camera, destroy the latest (duplicate) camera
        else
        {
            Destroy(gameObject);
        }
    }
	
	void Update ()
    {
        targetposition = new Vector3(FollowTarget.transform.position.x, FollowTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetposition, CameraSpeed * Time.deltaTime);
	}

}
