using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            Destroy(other.gameObject);  // Destroy the zombie
            Destroy(gameObject);       // Destroy the bullet
        }
        else if (other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);       // Destroy the bullet
        }
    }
}
