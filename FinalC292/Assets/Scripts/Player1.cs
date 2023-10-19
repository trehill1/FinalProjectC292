using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float moveAmount = 1.0f; // amount of space each movement
    public Animator animator;
    public float moveSpeed = 5f;
    private float animationDuration = .5f; // animation duration
    float movement = 0f;

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if(movement < 0 )
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            Move();
        }

        if (movement > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            Move();
        }

        if (movement == 0)
        {
            animator.SetTrigger("Idle");
        }
    }

    void Move()
    {
        animator.SetTrigger("Move");
        transform.position += new Vector3(moveSpeed*movement*Time.deltaTime, 0, 0); 
    }
}
