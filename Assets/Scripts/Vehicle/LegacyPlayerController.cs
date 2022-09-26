using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegacyPlayerController : MonoBehaviour
{
    public Wheel[] tractionWheels;
    public Wheel[] steerWheels;
    public float torque = 1000;
    private float verticalInput;
    private float horizontalInput;
    public void Update()
    {
        GetInput();
        UpdateWheels();
    }
    void GetInput()
    {
        verticalInput = Input.GetAxis("Vertical") * torque;
        horizontalInput = Input.GetAxis("Horizontal");
    }
    public void UpdateWheels()
    {
        foreach (Wheel wheel in tractionWheels)
        {
            wheel.Accelerate(verticalInput);
            wheel.UpdatePosition();
        }
        foreach (Wheel wheel in steerWheels)
        {
            wheel.Steer(horizontalInput);
            wheel.UpdatePosition();
        }
    }
}
