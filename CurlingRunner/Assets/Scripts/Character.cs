using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Help with the ragdoll: https://youtu.be/uVtDyPmorA0?si=P_PD7DA5FW92jSAW
public class Character : MonoBehaviour
{
    [SerializeField] Rigidbody2D chest;
    [SerializeField] Animator animator;

    [Range(0, 1000)]
    [SerializeField] float speed;

    // Jumping mechanic
    [Range(0, 10000)]
    [SerializeField] float jumpPower;
    bool isJumping = true;

    [Header("Grounding")]
    [SerializeField] RectTransform groundCheckTransform;
    [SerializeField] LayerMask playerMask;

    // To Dos
        // Sliding mechanic
        // Fix up ragdoll parts in terms of their rotation
    private void Update()
    {
        Vector2 horVel = this.transform.right * speed * Time.deltaTime * 100;
        chest.velocity = horVel;
        animator.Play("Walk");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = !isJumping;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckTransform.position, 1f, playerMask);
    }

    private void FixedUpdate()
    {
        // need to fix this
        if (IsGrounded() && !isJumping)
        {
            chest.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = !isJumping;
        }
        
    }

    public void AddSpeed(float factor)
    {
        speed += factor;
    }

    public void LoseSpeed(float factor)
    {
        speed -= factor;
    }

}
