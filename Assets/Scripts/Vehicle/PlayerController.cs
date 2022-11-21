using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody rb;
    [Header("Load")]
    public Transform[] unloadSpots;
    public Transform loadSpot;
    public float pickUpRange;
    public LayerMask loadLayer;
    [Header("Stats")]
    public float speed;
    public float steerSpeedMultiplier;
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
    private float wheelAngularVelocity;
    private float wheelRps;
    private float wheelYAngle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) LoadOrUnload();
    }
    private void FixedUpdate()
    {
        //Inputs
        accelerationInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");

        //Movement
        rb.MovePosition(transform.position + transform.forward * accelerationInput * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * steerInput * accelerationInput * steerSpeedMultiplier * Time.deltaTime);

        //Wheel direction
        wheelRps = (speed * accelerationInput) / circumference;
        wheelAngularVelocity = wheelRps * 360 * Time.deltaTime;
        for (int i = 0; i < rotatingWheels.Length; i++)
        {       
            rotatingWheels[i].Rotate(Vector3.right, wheelAngularVelocity, Space.Self);
        }
        wheelYAngle = Mathf.Lerp(0, maxSteerAngle * steerInput, Mathf.Abs(steerInput));
        for (int i = 0; i < steerWheels.Length; i++)
        {
            steerWheels[i].localRotation = Quaternion.Euler(steerWheels[i].localRotation.x, wheelYAngle, 0);
        }
    }

    public void LoadOrUnload()
    {
        if (CheckHasLoad(out GameObject load))
        {
            Unload(load);
        }
        else if (CheckHasLoadNear(out GameObject nearLoad))
        {
            Load(nearLoad);
        }
    }

    public void Unload(GameObject load)
    {
        if (!load) return;

        float range = 1f;
        int layerMask = LayerMask.GetMask("Scene");
        Transform unloadSpot = null;
        for (int i = 0; i < unloadSpots.Length; i++)
        {
            if (Physics.OverlapSphere(unloadSpots[i].position, range, layerMask).Length == 0)
            {
                unloadSpot = unloadSpots[i];
                break;
            }
        }

        if (unloadSpot)
        {
            load.transform.SetParent(null);
            load.transform.position = unloadSpot.position;
        }
    }

    public void Load(GameObject load)
    {
        if (!load) return;

        load.transform.SetParent(transform);
        load.transform.localPosition = loadSpot.localPosition;
        load.transform.localRotation = Quaternion.identity;
    }

    public bool CheckHasLoad(out GameObject load)
    {
        Collider[] colliders = Physics.OverlapSphere(loadSpot.position, 0.2f, loadLayer);
        if(colliders.Length > 0)
        {
            load = colliders[0].gameObject;
            return true;
        }

        load = null;
        return false;
    }
    public bool CheckHasLoadNear(out GameObject load)
    {
        Collider[] colliders = Physics.OverlapSphere(loadSpot.position, 3f, loadLayer);
        if (colliders.Length > 0)
        {
            load = colliders[0].gameObject;
            return true;
        }

        load = null;
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(loadSpot.position, 0.2f);
    }
}
