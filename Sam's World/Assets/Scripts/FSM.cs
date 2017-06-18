using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState {
    void Enter();
    void Execute();
    void Exit();

    //void PlayerTurn();
    //void EnemyTurn();
}
/*
public class StateMachine
{
    IState currentState;
    
    public void ChangeState(IState newState)
    {
        // Leave the current state.
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    } 

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }
}

public class TestState : IState
{
    Unit owner;

    public TestState(Unit owner) { this.owner = owner; }

    public void Enter()
    {
        Debug.Log("entering test state");
    }

    public void Execute()
    {
        Debug.Log("updating test state");
    }

    public void Exit()
    {
        Debug.Log("exiting test state");
    }

}

public class Unit : MonoBehaviour
{
    StateMachine stateMachine = new StateMachine();

    void Start()
    {
        stateMachine.ChangeState(new TestState(this));
    }

    void Update()
    {
        stateMachine.Update();
    }
}
*/
