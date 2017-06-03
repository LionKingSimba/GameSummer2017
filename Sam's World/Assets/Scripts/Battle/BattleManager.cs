using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

    GameObject player;
    GameObject[] allies;
    GameObject ally1;
    GameObject ally2;

    GameObject[] enemies;

    public Text[] statusPanels;

	// Use this for initialization
	void Start () {

		// Get the player, ally and enemy GameObjects.
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (allies == null)
        {
            allies = GameObject.FindGameObjectsWithTag("Ally");
            if (allies.Length > 0)
            {
                if (ally1 == null)
                {
                    ally1 = allies[0];
                }
                if (ally2 == null && allies.Length > 1)
                {
                    ally2 = allies[1];
                }
            }
        }

        Debug.Log("The Allies are: ");
        foreach (GameObject ally in allies)
        {
            Debug.Log(ally);
        }

        if (enemies == null)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }

        Debug.Log("The Enemies are: ");
        foreach (GameObject enemy in enemies)
        {
            Debug.Log(enemy);
        }

        // Display ally health and mana.
        displayStatus(player, 0);
        if (allies.Length > 0)
        {
            for (int i = 0; i < allies.Length; i++)
            {
                displayStatus(allies[i], i+1);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void displayStatus (GameObject character, int panel)
    /* Displays a character's health and mana.
     * 
     * Parameters:
     *      character: the character whose health and mana to display
     *      panel: The character panel to display on, in order from left to right, starting from 0.
     */
    {
        CharacterStatus status = character.GetComponent<CharacterStatus>();
        string name = status.characterName;
        int health = status.health;
        int mana = status.mana;

        Debug.Log("Health: " + health);
        Debug.Log("Mana: " + mana);

        statusPanels[panel].text = name + 
                                   "\nHealth: " + health + 
                                   "\nMana: " + mana;
    }

    
}
