using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Load")]
    public GameObject truckLoad;
    public GameObject groundLoad;
    public Transform[] unloadSpots;
    public Transform loadSpot;
    [Header("Stats")]
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
    public float wheelYAngle;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) LoadOrUnload();
    }
    private void FixedUpdate()
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
        wheelYAngle = Mathf.Lerp(0, maxSteerAngle * steerInput, Mathf.Abs(steerInput));
        for (int i = 0; i < steerWheels.Length; i++)
        {
            steerWheels[i].localRotation = Quaternion.Euler(steerWheels[i].localRotation.x, wheelYAngle, 0);
        }
    }

    public void LoadOrUnload()
    {
        if (truckLoad)
        {
            Unload();
        }
        else if (groundLoad)
        {
            Load();
        }
    }

    public void Unload()
    {
        if (truckLoad)
        {
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
                truckLoad.transform.SetParent(null);
                truckLoad.transform.position = unloadSpot.position;
                groundLoad = truckLoad;
                truckLoad = null;
            }
        }
    }

    public void Load()
    {
        if (groundLoad)
        {
            groundLoad.transform.SetParent(transform);
            groundLoad.transform.localPosition = loadSpot.localPosition;
            groundLoad.transform.localRotation = Quaternion.identity;

            truckLoad = groundLoad;
            groundLoad = null;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TruckLoad"))
        {
            groundLoad = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TruckLoad"))
        {
            groundLoad = null;
        }
    }
}
