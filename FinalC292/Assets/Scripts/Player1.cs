using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player1 : MonoBehaviour
{
    public float moveAmount = 1.5f; // amount of space each movement
    public Animator animator;
    public float moveSpeed = 5f;
    float movement = 0f;
    public GameManager gameManager;
    public bool hasMoved = false;
    public bool isStart = true;
    public bool isFishing = false;
    bool hasFished = false;


    void Update()
    {
        //if (gameManager.CurrentState == GameManager.TurnState.PlayerTurn)
        //
        if (Input.GetKeyDown(KeyCode.F)){
            animator.SetTrigger("Fishing");
            transform.position += new Vector3(0, .4f, 0);
            animator.SetTrigger("Idle");
            isFishing = true;
            hasFished = true;
        }

        


        movement = Input.GetAxis("Horizontal");

            
            if (movement < 0)
            {
            if (hasFished)
            {
                transform.position = new Vector3(1.1f, -1.82f, 0);
            }
                if (hasMoved == false)
                {
                    //Text Boxes
                    if (gameManager.FirstText.gameObject == true)
                    {
                    gameManager.FirstText.gameObject.SetActive(false);
                    }
                    if (gameManager.FirstTeleportBool == true)
                    {
                    gameManager.FirstTeleportText.gameObject.SetActive(false);
                    }
                    if (gameManager.FishingBool == true)
                    {
                    gameManager.FishingText.gameObject.SetActive(false);
                    }
                //Sprite and Movement
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    if (isStart == true)
                    {
                    Move(-moveAmount);
                    }else {
                    Move2(-moveAmount);
                    }

                 } 
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
            }

            if (movement > 0)
            {
            if (hasFished)
            {
                transform.position = new Vector3(1.1f, -1.82f, 0);
            }
            if (hasMoved == false) { 
                  //Text boxes
                  if (gameManager.FirstText.gameObject == true)
                   {
                   gameManager.FirstText.gameObject.SetActive(false);
                   }
                   if (gameManager.FirstTeleportBool == true)
                   {
                   gameManager.FirstTeleportText.gameObject.SetActive(false);
                   }
                    if (gameManager.FishingBool == true)
                    {
                    gameManager.FishingText.gameObject.SetActive(false);
                    }

                //sprite and movement
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    if (isStart == true)
                    {
                        
                        Move(moveAmount);
                    }else{
                    
                    Move2(moveAmount);
                    }
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

    void Move2(float amount)
    {
        float yValue = gameManager.spawnMedieval.transform.position.y;
        animator.SetTrigger("Move");
        transform.position = new Vector3(gameManager.spawnMedieval.transform.position.x + amount, yValue, gameManager.spawnMedieval.transform.position.z);
        hasMoved = true;
    }
}
