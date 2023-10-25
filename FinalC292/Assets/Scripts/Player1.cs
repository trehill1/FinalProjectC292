using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float moveAmount = 1.5f; // amount of space each movement
    public Animator animator;
    public float moveSpeed = 5f;
    private float animationDuration = .5f; // animation duration
    float movement = 0f;
    public GameManager gameManager;


    void Update()
    {
        if (gameManager.currentState == TurnState.PlayerTurn)
        {
            movement = Input.GetAxis("Horizontal");

            if (movement < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                Move(-moveAmount);
                gameManager.EndPlayerTurn();
            }

            if (movement > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                Move(moveAmount);
                gameManager.EndPlayerTurn();

            }

            if (movement == 0)
            {
                animator.SetTrigger("Idle");
            }
        }
    }

    void Move(float amount)
    {
        animator.SetTrigger("Move");
        transform.position += new Vector3(amount, 0, 0); 
    }
}
