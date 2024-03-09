using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotationSpeed = 30.0f;
    public Transform turretTransform; 
    private float lastFireTime;

    void Update()
    {
        float turretRotationInput = Input.GetAxis("Mouse X");
        RotateTurret(turretRotationInput);

    }

    void RotateTurret(float input)
    {
        turretTransform.Rotate(Vector3.up * input * rotationSpeed * Time.deltaTime);
    }
    
}
