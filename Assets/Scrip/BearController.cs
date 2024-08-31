using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public Animator animator;

    private float speed;
    private Vector3 direction;

    void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            animator.SetFloat("Speed", speed);
            animator.SetFloat("DirectionX", direction.x);
            animator.SetFloat("DirectionZ", direction.z);

            // Rotate bear towards the direction of movement
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
        }
        else
        {
            speed = 0;
            animator.SetFloat("Speed", speed);
        }

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Attack(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Attack(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Attack(3);
        }
    }

    void Attack(int attackType)
    {
        animator.SetBool("IsAttacking", true);
        animator.SetInteger("AttackType", attackType);
    }

    // This method should be called at the end of attack animations to reset the attack state
    public void OnAttackAnimationEnd()
    {
        animator.SetBool("IsAttacking", false);
    }
}
