using System;
using UnityEngine;
using System.Collections;

public class Opponent : MonoBehaviour
{
    public Rigidbody2D physic;

    public Transform player;
    
    public float speed;
    public float agroDistance;
    private Animator anim;
    private float timeBtwAttack;
    
    public int health;



    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
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

    void startHunting()
    {
        if (health <= 0)
            physic.velocity = new Vector2(0, 0);
                
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


