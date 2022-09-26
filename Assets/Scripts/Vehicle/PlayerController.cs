using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float steerSpeed;
    public float steerInput;
    public float accelerationInput;
    [Header("Wheels")]
    public float wheelRadius;
    public float maxSteerAngle;
    private float circumference => 3.14f * 2 * wheelRadius;
    public Transform[] steerWheels;
    public Transform[] inverseSteerWheels;
    public Transform[] rotatingWheels;
    [Header("Debug")]
    public float angularVelocity;
    public float rps;
    public float yAngle;
    public Vector3 steerEulerAngles;

    void Update()
    {
        accelerationInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");

        transform.position += transform.forward * accelerationInput * speed * Time.deltaTime;
        transform.Rotate(Vector3.up * steerInput * steerSpeed * accelerationInput * Time.deltaTime);

        rps = (speed * accelerationInput) / circumference;
        angularVelocity = rps * 360 * Time.deltaTime;
        for (int i = 0; i < rotatingWheels.Length; i++)
        {       
            rotatingWheels[i].Rotate(Vector3.right, angularVelocity, Space.Self);
        }
        yAngle = Mathf.Lerp(0, maxSteerAngle * steerInput, Mathf.Abs(steerInput));
        for (int i = 0; i < steerWheels.Length; i++)
        {
            steerWheels[i].localRotation = Quaternion.Euler(steerWheels[i].localRotation.x, yAngle, 0);
        }
    }
}
