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
        if (!camerainscene)
        {
            camerainscene = true;
            DontDestroyOnLoad(transform.gameObject);
        }
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
