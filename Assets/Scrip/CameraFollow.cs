using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target; // personajul
    public Vector3 offset = new Vector3(0, 2, -5); // offset-ul camerei față de personaj
    public float sensitivity = 5.0f; // sensibilitatea rotației camerei
    public float distance = 5.0f; // distanța față de personaj
    public float minYAngle = -60f; // unghiul minim pe axa Y
    public float maxYAngle = 60f; // unghiul maxim pe axa Y
    public float scrollSpeed = 2.0f; // viteza de zoom

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;

        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);

        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, 2.0f, 10.0f);
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 direction = rotation * Vector3.forward;
        transform.position = target.position - direction * distance + offset;
        transform.LookAt(target.position + offset);
    }
}

