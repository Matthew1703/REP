using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    public float health;
    public Animator anim;
    public float maxHealth;


    public void TakeHit(float damage)
    {
        health -= damage;
        anim.SetTrigger("hurt");
        
        if (health <= 0)
        {
            anim.SetBool("IsDead", true);
        }

    }
    
    
}
