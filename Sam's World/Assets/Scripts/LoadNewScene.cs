using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{

    public string SceneToLoad;
    public string ExitLocationName;

    private PlayerControls sceneplayer;

    // Use this for initialization
    void Start()
    {
        sceneplayer = FindObjectOfType<PlayerControls>();
    }

    // Update is called once per frame
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
