using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearAI : MonoBehaviour
{









    /*   
      public Transform player;
      public float chaseDistance = 10f;
      public float attackDistance = 2f;
      public float attackCooldown = 2f;

      private NavMeshAgent navMeshAgent;
      private Animator animator;
      private float lastAttackTime;
      private int currentAttack;

      void Start()
      {
          navMeshAgent = GetComponent<NavMeshAgent>();
          animator = GetComponent<Animator>();
          lastAttackTime = -attackCooldown;
          currentAttack = 0;  // Începem de la primul atac
      }

      void Update()
      {
          float distanceToPlayer = Vector3.Distance(transform.position, player.position);

          if (distanceToPlayer <= attackDistance && Time.time > lastAttackTime + attackCooldown)
          {
              AttackPlayer();
          }
          else if (distanceToPlayer <= chaseDistance)
          {
              ChasePlayer();
          }
          else
          {
              Idle();
          }

          UpdateAnimator();
      }

      void ChasePlayer()
      {
          navMeshAgent.isStopped = false;
          navMeshAgent.SetDestination(player.position);
      }


      void AttackPlayer()
      {
          navMeshAgent.isStopped = true;
          transform.LookAt(player);
          animator.SetBool("IsAttacking", true);

          currentAttack = (currentAttack % 3) + 1;  // Incrementăm și resetăm atacul după 3
          animator.SetInteger("AttackType", currentAttack);

          lastAttackTime = Time.time;

          // Aplicăm damage jucătorului
          if (player != null)
          {
              CharacterAttack jucator = player.gameObject.GetComponent<CharacterAttack>(); // Obținem componenta CharacterAttack de pe obiectul jucătorului
              if (jucator != null)
              {
                  jucator.SuferaDamage(10); // Aplicăm damage-ul la jucător
              }
          }
      }

          void Idle()
      {
          navMeshAgent.isStopped = true;
          animator.SetBool("IsAttacking", false);
          animator.SetFloat("Speed", 0);
      }

      void UpdateAnimator()
      {
          if (!navMeshAgent.isStopped)
          {
              Vector3 velocity = navMeshAgent.velocity;
              Vector3 localVelocity = transform.InverseTransformDirection(velocity);
              animator.SetFloat("Speed", velocity.magnitude);
              animator.SetFloat("DirectionX", localVelocity.x);
              animator.SetFloat("DirectionZ", localVelocity.z);
          }
      }

     // Metodă pentru a suferi damage
      public void SuferaDamage(int damage)
      {
          viata -= damage; // Scade viața cu damage-ul primit

          if (viata <= 0)
          {
              Moare(); // Dacă viața este mai mică sau egală cu zero, apelăm metoda Moare
          }
      }

      // Metodă pentru acțiunile ce se întâmplă când ursul moare
      void Moare()
      {
          // Implementează acțiunile specifice când ursul moare, de exemplu:
          // - Animații de moarte
          // - Sunete
          // - Dezactivarea sau distrugerea obiectului ursului
          Destroy(gameObject); // În exemplul simplificat, distrugem obiectul ursului



      }*/
}



