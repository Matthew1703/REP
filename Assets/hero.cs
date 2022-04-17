using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
     public float speed = 3f;
     public int lives = 5;
     public float jumpForce = 15f;

    public Rigidbody2D rb;
    private float moveInput;

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}
