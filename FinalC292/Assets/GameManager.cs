using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Player1 player1;
    public enum TurnState
    {
        PlayerTurn,
        EnemyTurn,
    }

    public Zombie zombie;

    public  TurnState currentState;

    public TurnState CurrentState
    {
        get { return currentState; }
    }

    private void Start()
    {
        //currentState = TurnState.PlayerTurn;
        //Debug.Log(currentState);
    }


    public void EndPlayerTurn()
    {
        //currentState = TurnState.EnemyTurn;
        player1.hasMoved = false; 
        Debug.Log(currentState);
        foreach(GameObject z in GameObject.FindGameObjectsWithTag("Zombie"))
        {
            z.GetComponent<Zombie>().Move();
        }
    }

    //public void EndEnemyTurn()
    //{
       // currentState = TurnState.PlayerTurn;
       // Debug.Log(currentState);
    //}
}
