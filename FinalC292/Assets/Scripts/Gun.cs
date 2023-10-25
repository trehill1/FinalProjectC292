using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public float shootSpeed = 20f;
    public Transform shootPoint; 
    public Animator animator;


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
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        if (transform.localScale.x < 0) 
        {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootSpeed*Time.deltaTime, 0);
        }
        else
        {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed*Time.deltaTime, 0);
        }
        animator.SetTrigger("Idle");
    }
}
