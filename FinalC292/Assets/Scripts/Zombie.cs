using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour

{
    public float moveAmount = 1.5f;
    public Animator animator;
    float moveSpeed = 5f;
    public GameManager gameManager;
    float movement = 0f;

    private void Update()
    {
        if (gameManager.CurrentState == GameManager.TurnState.EnemyTurn)
        {
            Move(moveAmount);
            movement = Input.GetAxis("Horizontal");

            if (movement == 0)
            {
                animator.SetTrigger("Idle");
                gameManager.EndEnemyTurn();
            }
        }
    }
    public void Move(float amount)
    {
        animator.SetTrigger("Move");
        transform.position += new Vector3(amount, 0, 0) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other);

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);  // Destroy the zombie
            Destroy(gameObject);       // Destroy the bullet
        }
    }
}