using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public GameObject FollowTarget;
    public float CameraSpeed;

    private Vector3 targetposition;

    private static bool camerainscene;

	// initialization
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
	
	// Update is called once per frame
	void Update ()
    {
        targetposition = new Vector3(FollowTarget.transform.position.x, FollowTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetposition, CameraSpeed * Time.deltaTime);
	}

}
