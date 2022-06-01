using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private float attackColdown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float coldownTimer = Mathf.Infinity;
    private Animator anim;
    public Health playerHealth;
    public Rigidbody2D physic;
    public float agroDistance;
    public Transform player;
    public float speed;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        coldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (coldownTimer >= attackColdown)
            {
                coldownTimer = 0;
                anim.SetTrigger("attack");
                DamagePlayer();
            }
        }
        
        float distToPlayer = Vector2.Distance(transform.position, player.position);

       if (distToPlayer < agroDistance)
        {
            startHunting();
        }
        else
        {
            StopHunting();
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);
        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeHit(damage);
        }
    }
    

   void startHunting()
    {
       // if (playerHealth <= 0)
         //   physic.velocity = new Vector2(0, 0);
                
       if (player.position.x > transform.position.x)
        {
            physic.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else if (player.position.x < transform.position.x)
        {
            physic.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void StopHunting()
    {
        physic.velocity = new Vector2(0, 0);
    }
    
}
