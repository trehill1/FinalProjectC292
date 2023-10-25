using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float moveAmount = 1.5f; // amount of space each movement
    public Animator animator;
    public float moveSpeed = 5f;
    public GameManager gameManager;

    // Update is called once per frame
    private void Update()
    {
        if (gameManager.CurrentState == GameManager.TurnState.EnemyTurn)
        {
            Move();
            gameManager.EndEnemyTurn();
            animator.SetTrigger("Idle");
        }
    }

    public void Move()
    {
        animator.SetTrigger("Move");
        transform.position += new Vector3(moveAmount, 0, 0);
    }
}