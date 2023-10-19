using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float moveAmount = 1.0f; // amount of space each movement
    public Animator animator;
    public float moveSpeed = .02f;
    private float animationDuration = 1.0f; // Assume animation duration is 1 second. Adjust as needed.

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        animator.SetFloat("Speed", 0);
    }

    void MoveLeft()
    {
        transform.position += new Vector3(-moveAmount, 0, 0);
        animator.SetFloat("LeftSpeed", moveSpeed);
        StartCoroutine(ResetSpeedAfterAnimation("LeftSpeed"));
    }

    void MoveRight()
    {
        transform.position += new Vector3(moveAmount, 0, 0);
        animator.SetFloat("RightSpeed", moveSpeed);
        StartCoroutine(ResetSpeedAfterAnimation("RightSpeed"));
    }

    IEnumerator ResetSpeedAfterAnimation(string parameterName)
    {
        // Wait for the duration of the animation
        yield return new WaitForSeconds(animationDuration);

        // Reset the speed value
        animator.SetFloat(parameterName, 0);
    }
}
