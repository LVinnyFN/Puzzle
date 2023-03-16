using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public Transform minAnchor, maxAnchor;

    public void OnDrawGizmos()
    {
        if (!minAnchor || !maxAnchor) return;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(minAnchor.position, 0.15f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(maxAnchor.position, 0.2f);
        Gizmos.DrawLine(minAnchor.position, maxAnchor.position);
    }
}
