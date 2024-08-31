using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public Transform camera;


    private void LateUpdate()
    {
        transform.LookAt(camera);
    }
}
