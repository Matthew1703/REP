using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heromove : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] int lives = 5;
    [SerializeField] float jumpForce = 15f;

    public Rigidbody2D rb;
    private float moveInput;

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown((KeyCode.Space)))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
