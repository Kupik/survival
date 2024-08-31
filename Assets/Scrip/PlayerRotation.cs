using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    Animator animator;
    public float rotationSpeed = 700f;
    CharacterController characterController;
    private Transform cameraTransform;
    public float walkSpeed = 2.0f;
    public float runSpeed = 6.0f;
    public float acceleration = 5.0f;
    public float decceleration = 5.0f;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        bool shiftPressed = Input.GetKey("left shift");

        // Rotație bazată pe direcția camerei și input-ul utilizatorului
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            characterController.Move(moveDirection.normalized * (shiftPressed ? runSpeed : walkSpeed) * Time.deltaTime);

            // Update animation parameters
            animator.SetFloat("Velocity X", direction.x);
            animator.SetFloat("Velocity Z", direction.z);
            animator.SetFloat("Speed", direction.magnitude);
        }
    }
}
