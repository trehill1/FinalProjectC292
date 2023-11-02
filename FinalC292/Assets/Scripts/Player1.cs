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
    public bool hasMoved = false;


    void Update()
    {
        //if (gameManager.CurrentState == GameManager.TurnState.PlayerTurn)
        //{
            movement = Input.GetAxis("Horizontal");

            if (movement < 0)
            {
                if (hasMoved == false)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    Move(-moveAmount);
                } 
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
            }

            if (movement > 0)
            {
                if (hasMoved == false)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    Move(moveAmount);
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
            }

            if (movement == 0)
            {
                animator.SetTrigger("Idle");
            }
        //}
    }

    void Move(float amount)
    {
        animator.SetTrigger("Move");
        transform.position += new Vector3(amount, 0, 0);
        hasMoved = true;
    }
}
