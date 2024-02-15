using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Force needs to be applied horizontally
    [Range(0, 150)]
    [SerializeField] float initialSpeed;
    private float speed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = initialSpeed;
    }

    private void Update()
    {
        if(speed < 0f) // Avoid reversing in the negative direction!
        {
            return;
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public float GetCurrentSpeed()
    {
        return speed;
    }

}
