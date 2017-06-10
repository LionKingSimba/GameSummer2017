using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{

    private static bool guiinscene;

	
	void Start ()
    {
        //if new scene has no gui, keep the past scene gui
        if (!guiinscene)
        {
            guiinscene = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        //if new scene already has gui, destroy the latest (duplicate) gui
        else
        {
            Destroy(gameObject);
        }
    }
	
	void Update ()
    {
		
	}
}
