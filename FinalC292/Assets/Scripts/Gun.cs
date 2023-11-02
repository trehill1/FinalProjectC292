using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public float shootSpeed = 20f;
    public Transform shootPoint; 
    public Animator animator;
    public Player1 player;
    public GameManager gameManager;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.CurrentState == GameManager.TurnState.PlayerTurn)
        {
            animator.SetTrigger("Shoot");
            Shoot();
            gameManager.EndPlayerTurn();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Bullet bullet1 = bullet.GetComponent<Bullet>();

        // Check player's facing direction using SpriteRenderer's flipX
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        Vector2 direction1 = sr.flipX ? Vector2.right : Vector2.left;

        // Apply velocity to bullet depending on direction
        bullet1.direction = direction1;
        bullet1.speed = shootSpeed;
        animator.SetTrigger("Idle");
        //Debug.Break();
    }
}
