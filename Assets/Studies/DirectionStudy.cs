using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DirectionStudy : MonoBehaviour
{
    [Header("Draw")]
    public bool drawCenter;
    public bool drawPivot;
    public bool drawPosition;
    public bool drawFrustum;
    [Header("Configs")]
    [Range(0,360*3)]public float angle;
    public float distance;
    public Vector3 center;
    public Vector3 offset;
    [Header("Result")]
    private Vector3 pivot;
    private Vector3 position;

    private Vector3 pivotForward;
    private Vector3 pivotRight;

    private Vector3 positionForward;    
    private Vector3 positionRight;    
    private Vector3 frustumCenter;    
    private Vector3 frustumRight;    
    private Vector3 frustumLeft;    

    private void OnDrawGizmos()
    {
        CalculatePosition();

        float radius = 0.5f;

        if (drawPosition)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(position, radius);
            Handles.Label(position, "Position");
            Gizmos.DrawWireSphere(position + positionForward, radius / 2);
            Gizmos.DrawLine(position, position + positionForward);
            Gizmos.DrawWireSphere(position + positionRight, radius / 3);
            Gizmos.DrawLine(position, position + positionRight);
        }

        if (drawPivot)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(pivot, radius);
            Handles.Label(pivot, "Pivot");
            Gizmos.DrawWireSphere(pivot + pivotForward, radius / 2);
            Gizmos.DrawLine(pivot, pivot + pivotForward);
            Gizmos.DrawWireSphere(pivot + pivotRight, radius / 3);
            Gizmos.DrawLine(pivot, pivot + pivotRight);
        }

        if (drawCenter)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(center, radius);
            Handles.Label(center, "Center");
        }

        if (drawFrustum)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(frustumRight, radius / 2);
            Gizmos.DrawWireSphere(frustumLeft, radius / 3);
            Gizmos.DrawLine(position, frustumCenter);
            Gizmos.DrawLine(position, frustumRight);
            Gizmos.DrawLine(position, frustumLeft);
        }
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
}