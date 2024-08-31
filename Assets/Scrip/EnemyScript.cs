using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.AI;


public class EnemyScript : MonoBehaviour
{


    NavMeshAgent navMeshAgent;
    private int HP = 100;
    public Animator animator;
    public Slider healthBar;


    public void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }



    void Update()
    {
        // controller auto direction
        Vector3 velocity = navMeshAgent.velocity;
        float speed = velocity.magnitude / navMeshAgent.speed;
        animator.SetFloat("Speed", speed);

        if (velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(velocity.normalized);
        }
        // controller auto direction


        // health(viata)
        healthBar.value = HP;    
    }

    public void TakeDamege(int damageAmount)
    {
        HP -= damageAmount;

        if(HP <= 0)
        {
            animator.SetTrigger("death");
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
          
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }

  
}