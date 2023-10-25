using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public float shootSpeed = 1000f;
    public Transform shootPoint; 
    public Animator animator;
    Player1 player;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Shoot");
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Check player's facing direction using SpriteRenderer's flipX
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        float direction = sr.flipX ? 1 : -1;

        // Apply velocity to bullet depending on direction
        rb.velocity = new Vector2(shootSpeed * direction, 0);
        animator.SetTrigger("Idle");
    }
}
