using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{

    GameObject player;
    List<GameObject> allies = new List<GameObject>(); // allies[0] is player, allies[1] and allies[2] are the other party members.
    GameObject ally1;
    GameObject ally2;

    List<GameObject> enemies = new List<GameObject>(); // List storing enemies

    List<GameObject> entities = new List<GameObject>(); // List of all allies and enemies.
    int entitiesPointer = 0; // A pointer to a specific entity in the list.
    List<GameObject> turnQueue = new List<GameObject>(); // Queue of who will go next.

    public Text[] statusPanels;
    public Text turnQueuePanel;

    // Menu Buttons
    public Button attackButton;
    public Button abilitiesButton;
    public Button itemsButton;
    public Button fleeButton;

    enum BattleState
    {
        BattleStart,
        PlayerTurn,
        EnemyTurn
    };

    BattleState currentState;
    bool turnEnded = false;

    // Use this for initialization
    void Start()
    {
        currentState = BattleState.BattleStart;

        // Get the player, ally and enemy GameObjects.
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            allies.Insert(0, player);
        }

        allies.AddRange(GameObject.FindGameObjectsWithTag("Ally"));
        //Debug.Log("Ally Count: " + allies.Count);
        if (allies.Count > 0)
        {
            if (ally1 == null)
            {
                ally1 = allies[1];
            }
            if (ally2 == null && allies.Count > 2)
            {
                ally2 = allies[2];
            }
        }

        //Debug.Log("The Allies are: ");
        //foreach (GameObject ally in allies)
        //{
        //    Debug.Log(ally);
        //}

        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));

        //Debug.Log("The Enemies are: ");
        //foreach (GameObject enemy in enemies)
        //{
        //    Debug.Log(enemy);
        //}

        // Display ally health and mana.
        for (int i = 0; i < allies.Count; i++)
        {
            displayStatus(allies[i], i);
        }

        entities.AddRange(allies);
        entities.AddRange(enemies);
        //Debug.Log("entities: ");
        //foreach (GameObject entity in entities)
        //{
        //    Debug.Log(entity);
        //}

        // Battle turn loop
        battle();
    }

    // Update is called once per frame
    void Update()
    {

        // Each frame check if the turn ended. 
        if (turnEnded)
        {
            Debug.Log("Turn Ended");
            turnEnded = false;
            battle();
        }   
    }

    void displayStatus(GameObject character, int panel)
    /* Displays a character's health and mana.
     * 
     * Parameters:
     *      character: the character whose health and mana to display
     *      panel: The character panel to display on, in order from left to right, starting from 0.
     */
    {
        CharacterStatus status = character.GetComponent<CharacterStatus>();
        string name = status.characterName;
        int currentHealth = status.currentHealth;
        int currentMana = status.currentMana;
        int maxHealth = status.maxHealth;
        int maxMana = status.maxMana;

        //Debug.Log("Current Health: " + currentHealth);
        //Debug.Log("Current Mana: " + currentMana);

        statusPanels[panel].text = name +
                                   "\nHP: " + currentHealth + "/" + maxHealth +
                                   "\nMP: " + currentMana + "/" + maxMana;
    }

    void fillTurnQueue()
    {
        /* 
         * Fills the turnQueue to a maximum of 4 entities.
         * Displays the turnQueue on the UI.
         */

        bool queueNotFull = true;
        while (queueNotFull)
        {
            // Loop through list of entities, starting at the pointer. 
            for (int i = entitiesPointer; i < entities.Count; i++)
            {
                bool turn = entities[i].GetComponent<CharacterStatus>().getATB();

                // If the entity's ATB meter is maxed, add it to turnQueue.
                if (turn)
                {
                    turnQueue.Add(entities[i]);
                }

                // If there are four in the turnQueue, then the queue is full.
                if (turnQueue.Count == 4)
                {
                    queueNotFull = false;
                    entitiesPointer = i;
                    break;
                }
            }

            // After we are done looping through all entities, reset the pointer to 0.
            entitiesPointer = 0;
        }

        //Debug.Log("Turn Queue: ");
        //foreach (GameObject entity in turnQueue)
        //{
        //    Debug.Log(entity);
        //}
        //Debug.Log("Queue Length: " + turnQueue.Count);

        turnQueuePanel.text = "TURN\n" +
                              turnQueue[0].GetComponent<CharacterStatus>().characterName + "\n" +
                              turnQueue[1].GetComponent<CharacterStatus>().characterName + "\n" +
                              turnQueue[2].GetComponent<CharacterStatus>().characterName + "\n" +
                              turnQueue[3].GetComponent<CharacterStatus>().characterName + "\n";
    }

    void playerTurn()
    {
        /*
         * Conducts a player turn. 
         */

        // Set buttons to active.

        Debug.Log("player turn");
        attackButton.interactable = true;
        abilitiesButton.interactable = true;
        itemsButton.interactable = true;
        fleeButton.interactable = true;
    }

    void enemyTurn()
    {
        /* 
         * Conducts an enemy turn
         */

        /* Turns Menus buttons to inactive */
        attackButton.interactable = false;
        abilitiesButton.interactable = false;
        itemsButton.interactable = false;
        fleeButton.interactable = false;
    }

    public void endTurn()
    {
        /* Removes the first character of the turn queue. Sets the battlestate according to the next person in the turn queue. */
        turnQueue.RemoveAt(0);
        Debug.Log("turnQueue: ");
        foreach (GameObject item in turnQueue)
        {
            Debug.Log(item);
        }
        Debug.Log("Queue Length: " + turnQueue.Count);

        GameObject nextTurn = turnQueue[0];
        switch (nextTurn.tag)
        {
            case "Player":
                // Do stuff
                currentState = BattleState.PlayerTurn;
                break;
            case "Ally":
                // Do stuff
                currentState = BattleState.PlayerTurn;
                break;
            case "Enemy":
                // Do stuff
                currentState = BattleState.EnemyTurn;
                break;
        }
        print(currentState);

        turnEnded = true;
    }



    void battle()
    {
        /* 
         * The battle loop:
         * 1. Fill turnQueue
         * 2. Conduct the turn of the entity at the front of turnQueue and remove them from the queue.
         * 3. Check if battle is over. If yes, go to battle results screen.
         * 4. If not, return to 1.
        */

        // 1.
        fillTurnQueue();

        // 2.
        if (turnQueue[0].tag == "Enemy")
        {
            // Conduct enemy turn
            currentState = BattleState.EnemyTurn;

        }
        else if (turnQueue[0].tag == "Player" || turnQueue[0].tag == "Ally")
        {
            // Conduct player turn
            currentState = BattleState.PlayerTurn;
        }
        else
        {
            Debug.Log("Entity not tagged!!!!!!");
        }

        switch(currentState)
        {
            case BattleState.PlayerTurn:
                // Do stuff
                playerTurn();
                break;
            case BattleState.EnemyTurn:
                // Do stuff
                enemyTurn();
                break;
            case BattleState.BattleStart:
                // Do stuff
                break;
        }
            
    }
}