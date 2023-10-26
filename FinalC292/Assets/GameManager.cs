using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public enum TurnState
    {
        PlayerTurn,
        EnemyTurn,
    }

    public Zombie zombie; // Reference to the Zombie script
    private TurnState currentState;

    public TurnState CurrentState
    {
        get { return currentState; }
    }

    private void Start()
    {
        currentState = TurnState.PlayerTurn;
    }

    private void Update()
    {
        switch (currentState)
        {
            case TurnState.PlayerTurn:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    EndPlayerTurn();
                }
                break;

            case TurnState.EnemyTurn:
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
}
