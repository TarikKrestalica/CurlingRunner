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
    [Range(0, 100)]
    [SerializeField] float jumpPower;
    bool isJumping = false;

    [Header("Grounding")]
    [SerializeField] RectTransform groundCheckTransform;
    [SerializeField] LayerMask playerMask;

    private string result = "ParticipationTrophy";

    // To Dos
    // Sliding mechanic
    // Fix up ragdoll parts in terms of their rotation
    private void Update()
    {
        if (speed < 0)
            return;

        this.transform.Translate(this.transform.right * speed * Time.deltaTime * Time.deltaTime);
        animator.Play("Walk");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckTransform.position, 1f, playerMask);
    }

    private void FixedUpdate()
    {
        // need to fix this
        if (IsGrounded() && isJumping == true)
        {
            chest.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = false;
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

    public float GetSpeed()
    {
        return speed;
    }

    public string GetResult()
    {
        return result;
    }

    public void SetResult(string text)
    {
        result = text;
    }
}
