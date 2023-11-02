using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Vector2 direction;
    public GameManager game;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other);

        if (other.gameObject.CompareTag("Zombie"))
        {
            Destroy(other.gameObject);  // Destroy the zombie
            Destroy(gameObject);       // Destroy the bullet
            game.EndPlayerTurn();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject); //Destroy the bullet
        }
    }
    private void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime);
    }
}
