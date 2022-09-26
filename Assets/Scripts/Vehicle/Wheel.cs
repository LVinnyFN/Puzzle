using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float maxAngle = 30f;
    private float turnAngle;
    [SerializeField]private WheelCollider wheelCol;
    [SerializeField]private Transform wheelMesh;

    public void Steer(float steerInput)
    {
        turnAngle = steerInput * maxAngle;
        wheelCol.steerAngle = turnAngle;
    }

    public void Accelerate(float powerInput)
    {
        wheelCol.motorTorque = powerInput;
    }

    public void UpdatePosition()
    {
        wheelCol.GetWorldPose(out Vector3 pos, out Quaternion rot);

        wheelMesh.transform.position = pos;
        wheelMesh.transform.rotation = rot;
    }
}
