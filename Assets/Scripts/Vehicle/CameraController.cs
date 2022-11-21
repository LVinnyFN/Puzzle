using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform minAnchor, maxAnchor;
    public Transform target;
    public Transform cam;
    public float smooth;

    private void OnValidate()
    {
        FixedUpdate();
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(minAnchor.position, 0.2f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(maxAnchor.position, 0.2f);
    }

    void FixedUpdate()
    {
        if (!target) return;

        Vector3 pos;
        pos.x = Mathf.Clamp(target.position.x, minAnchor.position.x, maxAnchor.position.x);
        pos.y = Mathf.Clamp(target.position.y, minAnchor.position.y, maxAnchor.position.y);
        pos.z = Mathf.Clamp(target.position.z, minAnchor.position.z, maxAnchor.position.z);
        cam.position = Vector3.Lerp(cam.position, pos, Time.deltaTime * smooth);

        cam.LookAt(target.position);
    }
}
