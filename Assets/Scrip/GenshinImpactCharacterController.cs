using UnityEngine;

public class GenshinImpactCharacterController : MonoBehaviour
{
    Animator animator;
    CharacterController characterController;

    public float walkSpeed = 2.0f;
    public float runSpeed = 6.0f;
    public float acceleration = 5.0f;
    public float decceleration = 5.0f;

    private Vector3 currentVelocity = Vector3.zero;

    private Transform cameraTransform;
    public float rotationSpeed = 700f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }

        if (characterController == null)
        {
            Debug.LogError("CharacterController component not found on " + gameObject.name);
        }

        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (animator == null || characterController == null) return;

        // Connect button controller
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool backwardPressed = Input.GetKey("s");
        bool shiftPressed = Input.GetKey("left shift");

        // Calculate target direction
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
