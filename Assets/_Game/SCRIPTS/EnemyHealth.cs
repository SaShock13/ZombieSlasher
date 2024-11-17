using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField, Range(10,2000)] private int health = 20;
    private Animator animator;
    private Enemy enemy;
    private Rigidbody rb;
    private Collider bodyCollider;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        enemy = GetComponentInChildren<Enemy>();
        rb = GetComponent<Rigidbody>();
        bodyCollider = GetComponent<Collider>();
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
        //animator.SetTrigger("Death");

        enemy.SetState(EnemyBehState.Death);
        //rb.isKinematic = true;
        //bodyCollider.enabled = false;
    }


    /// <summary>
    /// ×èñòî äëÿ òåñòèðîâàíèÿ
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Death();
        }
    }

}
