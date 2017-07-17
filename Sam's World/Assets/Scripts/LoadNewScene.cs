using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

//script to handle entry points (when moving to a new scene)
public class LoadNewScene : MonoBehaviour
{

    public string SceneToLoad;
    public string ExitLocationName;

    private PlayerControls sceneplayer;

    
    void Start()
    {
        sceneplayer = FindObjectOfType<PlayerControls>();
    }
    
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D boxcolliderobj)
    {
        if (boxcolliderobj.gameObject.name == "Player")
        {
            //Application.LoadLevel(SceneToLoad);
            SceneManager.LoadScene(SceneToLoad);
            sceneplayer.EntryLocationName = ExitLocationName; //new scene player's location will be exit location that old scene player triggered
        }
    }

}
