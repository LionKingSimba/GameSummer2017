using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour {

    BattleManager battleManager;

	// Use this for initialization
	void Start () {
        battleManager = gameObject.GetComponent<BattleManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void attack()
    {
        Debug.Log("Player Attacked!!!!");
        battleManager.endTurn(); // Tell the battle manager to go to the next character's turn.
    }

    public void items()
    {
        Debug.Log("Items");
        battleManager.endTurn(); // Tell the battle manager to go to the next character's turn.
    }

    public void run()
    {
        Debug.Log("Running");
        battleManager.endTurn(); // Tell the battle manager to go to the next character's turn.
    }

    public void abilities()
    {
        Debug.Log("Abilities");
        battleManager.endTurn(); // Tell the battle manager to go to the next character's turn.
    }

    public bool endPlayerTurn()
    {
        /* Returns true to signify the player turn ending. */
        return true;
    }
     
}
