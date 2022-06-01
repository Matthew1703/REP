using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class heromove : MonoBehaviour
{
   public float speed = 10f;
   public float jumpForce;

   public bool isGrounded = true;
   public float groundRadius = 0.3f;
   public Transform groundCheck;
   public LayerMask groundMask;

   public Rigidbody2D rb;
   public Animator anim;
   public SpriteRenderer sprite;
   
   private void FixedUpdate()
   {
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
  
   }

   private void Update()
   { 
    
   if (Input.GetButton("Horizontal"))
    Run();
   //Бег
   
   if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
    Jump();
   //Прыжок
   
   
   if (Input.GetAxis("Vertical") == 0)
    anim.SetBool("jump", false);
   else
   {
    anim.SetBool("jump", true);
   }
   //Анимация прыжка
   
   
   if (Input.GetAxis("Horizontal") == 0) 
    anim.SetBool(("run"), false);
   else
   {
    anim.SetBool(("run"), true);
   }
   //Анимация бегa
   
   }
   
   
   private void Awake()
   {
    rb = GetComponent<Rigidbody2D>();
   anim = GetComponent<Animator>();
   sprite = GetComponentInChildren<SpriteRenderer>();
   }

   private void Run()
   {
    Vector3 dir = transform.right * Input.GetAxis("Horizontal");
   transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
   sprite.flipX = dir.x > 0.0f;
   }

   private void Jump()
   {
    rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
   }
   
}





