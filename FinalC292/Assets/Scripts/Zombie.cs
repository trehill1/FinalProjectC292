using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour

{
    public float moveAmount = 1f;
    public Animator animator;
    private GameManager gameManager;
    //bool hasMoved = false;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        int rand = Random.Range(1,2);
        moveAmount = rand;
    }

    public void Move()
    {
        //animator.SetTrigger("Move");
        transform.position += new Vector3(moveAmount, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other);

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);  // Destroy the player
            Destroy(gameObject);       // Destroy the zombie
        }
    }
}