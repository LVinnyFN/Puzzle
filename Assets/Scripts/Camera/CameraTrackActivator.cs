using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrackActivator : MonoBehaviour
{
    public CameraController cameraController;
    public CameraTrack cameraTrack;
    public Vector3 size = Vector3.one;

    private void Awake()
    {
        Vector3 pivot = new Vector3(0, size.y / 2, 0);
        BoxCollider box = gameObject.AddComponent<BoxCollider>();
        box.size = size;
        box.center = pivot;
        box.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player))
        {
            Debug.Log("Entering Camera Zone: " + gameObject.name);
            cameraController.SetCameraTrack(cameraTrack);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Vector3 pivot = transform.position;
        pivot.y += size.y / 2;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(pivot, size);
    }
}
