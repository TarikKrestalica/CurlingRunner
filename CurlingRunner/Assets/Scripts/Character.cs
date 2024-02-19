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
    [Range(0, 200)]
    [SerializeField] float jumpPower;
    bool isJumping = false;

    [Header("Grounding")]
    [SerializeField] RectTransform groundCheckTransform;
    [SerializeField] LayerMask playerMask;

    private string result = "Participation Trophy";
    private bool isWalled = false;

    // To Dos
    // Sliding mechanic
    // Fix up ragdoll parts in terms of their rotation
    private void Update()
    {
        if (speed < 0)
            return;

        if (this.transform.position.y < -50)
        {
            this.transform.Translate(this.transform.right * 0);
            return;
        }

        this.transform.Translate(this.transform.right * speed * Time.deltaTime);
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
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        Debug.DrawRay(hit.point, -Vector2.up);
        // need to fix this
        if (IsGrounded() && isJumping == true)
        {
            chest.AddForce(Vector2.up * jumpPower * 5, ForceMode2D.Impulse);
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

    public void SetWalled(bool toggle)
    {
        isWalled = toggle;
    }

    public bool GetWalled()
    {
        return isWalled;
    }
}


