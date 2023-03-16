using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Camera cam;
    public CameraTrack track;
    public float smooth;
    [Range(0,1)]public float lerp;

    private bool on = true;
    private float minX, maxX, minY, maxY, minZ, maxZ;
    private void Awake()
    {
        if (!on || !target || !track) return;

        cam.transform.position = track.minAnchor.transform.position;
        cam.transform.LookAt(target.position);
    }

    void FixedUpdate()
    {
        if (!on || !target || !track) return;

        minX = Mathf.Min(track.minAnchor.position.x,track.maxAnchor.position.x);
        minY = Mathf.Min(track.minAnchor.position.y,track.maxAnchor.position.y);
        minZ = Mathf.Min(track.minAnchor.position.z,track.maxAnchor.position.z);
        maxX = Mathf.Max(track.minAnchor.position.x,track.maxAnchor.position.x);
        maxY = Mathf.Max(track.minAnchor.position.y,track.maxAnchor.position.y);
        maxZ = Mathf.Max(track.minAnchor.position.z,track.maxAnchor.position.z);

        Vector3 pos;
        pos.x = Mathf.Clamp(target.position.x, minX, maxX);
        pos.y = Mathf.Clamp(target.position.y, minY, maxY);
        pos.z = Mathf.Clamp(target.position.z, minZ, maxZ);

        cam.transform.position = Vector3.Lerp(cam.transform.position, pos, Time.deltaTime * smooth);

        cam.transform.LookAt(target.position);
    }

    public void SetCameraTrack(CameraTrack cameraTrack)
    {
        if(cameraTrack) this.track = cameraTrack;
    }

    public void TurnOn() => on = true;
    public void TurnOff() => on = false;
}
