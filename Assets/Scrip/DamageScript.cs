using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageScript : MonoBehaviour
{

    public int damageAmount = 20;
    private CharacterAttack characterAttack;

    void Start()
    {
        characterAttack = GetComponent<CharacterAttack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    /*
    public int damageAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyScript>().TakeDamege(damageAmount);
        }
    }
    */
}
