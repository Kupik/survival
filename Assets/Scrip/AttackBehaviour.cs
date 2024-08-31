using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.AI;





public class AttackBehaviour : StateMachineBehaviour
{
    Transform player;
    public int damageAmount = 20;
    private bool hasDealtDamage; // Variabilă pentru a urmări dacă s-a aplicat deja damage

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hasDealtDamage = false; // Initializăm variabila la false la începutul stării de atac
        Debug.Log("Monster is attacking!"); // Mesaj de debug pentru începutul stării de atac
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (!hasDealtDamage && distance <= 3)
        {
            DealDamage(animator.transform.position); // Trimite poziția animatorului pentru detectarea coliziunilor
            hasDealtDamage = true; // Marcăm că damage-ul a fost aplicat în cadrul acestei stări de atac
        }

        if (distance > 3)
        {
            animator.SetBool("isAttacking", false);
        }

        if (distance > 15)
        {
            animator.SetBool("isChasing", false);
        }
    }

    void DealDamage(Vector3 center)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(center, 3.5f);

        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.CompareTag("Player"))
            {
                enemy.GetComponent<DamageDeathScript>().TakeDamage(damageAmount); // Aplică damage la scriptul jucătorului
                Debug.Log("Player took damage from monster!"); // Mesaj de debug pentru aplicarea daunelor
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hasDealtDamage = false; // Resetează variabila pentru următoarea intrare în starea de atac
    }

}
