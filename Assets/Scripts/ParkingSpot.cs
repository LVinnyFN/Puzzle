using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerController player)) 
        {
            GameController.Instance.OnPlayerReachGoal();
        }
    }
}
