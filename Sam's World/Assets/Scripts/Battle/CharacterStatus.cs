using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{

    /* This script handles the character's stats (health, attack, mana, etc.)  as well as equipment. 
     Can be for both enemies and allies. */

    public string characterName;

    public int maxHealth;
    public int currentHealth;

    public int maxATB;
    public int currentATB;

    public int maxMana;
    public int currentMana;

    public int strength;
    public int intelligence;
    public int dexterity;
    public int luck;
    public int speed;

    public int defense;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool getATB()
    {
        currentATB += speed;
        if (currentATB >= 100)
        {
            currentATB -= 100;
            return true;
        }
        return false;
    }

}