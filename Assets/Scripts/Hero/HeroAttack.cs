using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Animator anim;
    public int damage;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("attack");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<Health>().TakeHit(damage);
                }
           }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
