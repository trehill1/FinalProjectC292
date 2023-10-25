using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;


public enum TurnState
{
    PlayerTurn,
    EnemyTurn,
}
public class GameManager : MonoBehaviour
{
    public TurnState currentState;


    private void Start()
    {
        currentState = TurnState.PlayerTurn;
    }

    private void Update()
    {
        switch (currentState)
        {
            case TurnState.PlayerTurn:

                // If a certain condition is met, you can end the player's turn.
                if (Input.GetKeyDown(KeyCode.Space)) 
                {
                    EndPlayerTurn();
                }
                break;

            case TurnState.EnemyTurn:
                HandleEnemyActions();

                // If a certain condition is met, you can end the enemy's turn.
                if (Input.GetKeyDown(KeyCode.Return)) 
                {
                    EndEnemyTurn();
                }
                break;
        }
    }

    public void EndPlayerTurn()
    {
        currentState = TurnState.EnemyTurn;
    }

    public void EndEnemyTurn()
    {
        currentState = TurnState.PlayerTurn;
    }

    void HandleEnemyActions() { 

    }
}
