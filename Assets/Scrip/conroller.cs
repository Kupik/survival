using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conroller : MonoBehaviour
{

     public float walkSpeed = 2.0f;
     public float runSpeed = 6.0f;
     public float rotationSpeed = 700.0f;
     private Animator animator;
     private CharacterController characterController;
     void Start() {
         animator = GetComponent<Animator>();
         characterController = GetComponent<CharacterController>(); 
     }
     void Update() {
         float velocityX = Input.GetAxis("Horizontal");
         float velocityZ = Input.GetAxis("Vertical");
         Vector3 direction = new Vector3(velocityX, 0, velocityZ).normalized;
         if (direction.magnitude >= 0.1f)   {
             float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
             float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
             transform.rotation = Quaternion.Euler(0, angle, 0);
             Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
             float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
             characterController.Move(moveDir.normalized * speed * Time.deltaTime);
             animator.SetFloat("Speed", speed);
             animator.SetFloat("Velocity X", velocityX);
             animator.SetFloat("Velocity Z", velocityZ);
         }
         else
         {
             animator.SetFloat("Speed", 0);
             animator.SetFloat("Velocity X", 0);
             animator.SetFloat("Velocity Z", 0);   
         }   
     }
    




}
