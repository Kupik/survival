using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAttack : MonoBehaviour
{
    private Animator anim;
    private bool isAttacking;

    public int damageAmount = 20;

    void Start()
    {
        anim = GetComponent<Animator>();
        isAttacking = false;
    }

    void Update()
    {
        // Verificăm input-ul pentru a începe animațiile de atac
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            StartCoroutine(AttackRoutine("hit1", 1.0f)); // Atacul principal cu click stânga mouse
        }

        if (Input.GetKey(KeyCode.Z) && !isAttacking)
        {
            StartCoroutine(AttackRoutine("hit2", 0.5f)); // Atac secundar cu tasta Z
        }

        if (Input.GetKey(KeyCode.X) && !isAttacking)
        {
            StartCoroutine(AttackRoutine("hit3", 0.75f)); // Alt atac secundar cu tasta X
        }
    }

    IEnumerator AttackRoutine(string attackAnimation, float attackIntensity)
    {
        isAttacking = true;

        anim.SetFloat("AttackIntensity", attackIntensity);
        anim.SetBool(attackAnimation, true);

        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        anim.SetBool(attackAnimation, false);
        anim.SetFloat("AttackIntensity", 0.0f);

        isAttacking = false;

        // După ce animația s-a terminat, aplicăm daune inamicilor
        DealDamage();
    }

    void DealDamage()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, 1.5f); // Schimb valoarea 1.5f cu raza de detecție dorită

        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyScript>().TakeDamege(damageAmount);
            }
        }
        
    }

   
}