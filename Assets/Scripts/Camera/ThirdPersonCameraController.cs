using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("References")]
    public Transform Camera;
    public Transform Target;

    [Header("Configs")]
    [Range(0,360*3)]public float angle;
    public float moveSpeed;
    public float rotateSpeed;
    public float distance;
    public Vector3 offset;
    public Vector3 lookOffset;
    private Vector3 velocity;

    private Vector3 center;
    private Vector3 pivot;
    private Vector3 position;

    private Vector3 pivotForward;
    private Vector3 pivotRight;
    private Vector3 positionForward;
    private Vector3 positionRight;

    [Header("Mouse Delta")]
    private Vector2 mousePosLastFrame;

    [Header("Draw Gizmos")]
    public bool drawCenter;
    public bool drawPivot;
    public bool drawPosition;
    public bool drawFrustum;
    private float drawRadius = 0.5f;
    private Vector3 frustumCenter;
    private Vector3 frustumRight;
    private Vector3 frustumLeft;


    private Vector3 A;
    private Vector3 B;
    private Vector3 T;

    private void OnValidate()
    {
        center = Target.position;
        CalculatePosition();
        angle += Input.GetAxis("Mouse X") * rotateSpeed;
        Camera.position = position;
        Camera.LookAt(position + positionForward + lookOffset);
    }
    private void Update()
    {
        center = Target.position;
        CalculatePosition();
        angle += Input.GetAxis("Mouse X") * rotateSpeed;
        Camera.position = Vector3.SmoothDamp(Camera.position, position, ref velocity, moveSpeed);
        //Camera.position = position;
        Camera.LookAt(Camera.position + positionForward + lookOffset);
    } 

    private void CalculatePosition()
    {
        float radians = angle * Mathf.Deg2Rad;
        Vector3 pivotDirection = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians));
        pivot = center + (pivotDirection * distance);

        pivotForward = (center - pivot).normalized;
        pivotRight = -new Vector3(-pivotForward.z, 0, pivotForward.x);

        // AX * B.x + AY * B.y + AZ * B.z;
        position = pivot + (pivotRight * offset.x + pivotForward * offset.z) + new Vector3(0, offset.y, 0);

        float camViewDegrees = 60;
        float camViewRadians = camViewDegrees * Mathf.Deg2Rad;
        float camViewDistance = 1000;

        positionForward = pivotForward;
        positionRight = pivotRight;
        float cos = Mathf.Cos(camViewRadians);
        float sin = Mathf.Sin(camViewRadians);
        float negCos = Mathf.Cos(-camViewRadians);
        float negSin = Mathf.Sin(-camViewRadians);

        frustumCenter = position + (camViewDistance * positionForward);
        frustumRight = position + (camViewDistance * (positionForward * negCos + positionRight * negSin));
        frustumLeft = position + (camViewDistance * (positionForward * cos + positionRight * sin));
    }

    private void OnDrawGizmos()
    {
        if (drawPosition)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(position, drawRadius);
            Handles.Label(position, "Position");
            Gizmos.DrawWireSphere(position + positionForward, drawRadius / 2);
            Gizmos.DrawLine(position, position + positionForward);
            Gizmos.DrawWireSphere(position + positionRight, drawRadius / 3);
            Gizmos.DrawLine(position, position + positionRight);
        }

        if (drawPivot)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(pivot, drawRadius);
            Handles.Label(pivot, "Pivot");
            Gizmos.DrawWireSphere(pivot + pivotForward, drawRadius / 2);
            Gizmos.DrawLine(pivot, pivot + pivotForward);
            Gizmos.DrawWireSphere(pivot + pivotRight, drawRadius / 3);
            Gizmos.DrawLine(pivot, pivot + pivotRight);
        }

        if (drawCenter)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(center, drawRadius);
            Handles.Label(center, "Center");
        }

        if (drawFrustum)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(frustumRight, drawRadius / 2);
            Gizmos.DrawWireSphere(frustumLeft, drawRadius / 3);
            Gizmos.DrawLine(position, frustumCenter);
            Gizmos.DrawLine(position, frustumRight);
            Gizmos.DrawLine(position, frustumLeft);
        }
    }
}