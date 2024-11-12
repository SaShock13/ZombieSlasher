using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 1000;
    private Animator animator;
    private Enemy enemy;
    private Rigidbody rb;
    private Collider collider;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        enemy = GetComponentInChildren<Enemy>();
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    public void TakeDamage(int damage)
    {
        if (enemy.isAlive)
        {

            if (damage > 0)
            {
                health -= damage;
                print($"Health : {health}");
                if (health <= 0)
                {
                    Death();
                    print($"Enemy is Dead");
                }
                else animator.SetTrigger("Hit");
            }
            
        }
    }

    private void Death()
    {
        //ÍÅ ÓÌÈÐÀÅÒ ÈÇ ÑÎÑÒÎßÍÈß ÀÒÀÊÈ!!!
        animator.SetTrigger("Death");
        enemy.isAlive = false;
        rb.isKinematic = true;
        collider.enabled = false;
    }
}
