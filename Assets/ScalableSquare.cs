using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalableSquare : MonoBehaviour
{
    public Vector3 scale;
    public GameObject[] corners;
    public GameObject[] sides;
    public new BoxCollider collider;
    public float cornerFactor;

    public void OnValidate()
    {
        Vector3 targetPosition;
        Vector3 targetScale;

        //CORNERS
        targetPosition = transform.position;
        targetPosition.x += (scale.x / 2);
        targetPosition.z += (scale.z / 2);
        if(corners.Length > 0 && corners[0]) corners[0].transform.position = targetPosition;

        targetPosition = transform.position;
        targetPosition.x += (scale.x / 2);
        targetPosition.z -= (scale.z / 2);
        if (corners.Length > 1 && corners[1]) corners[1].transform.position = targetPosition;

        targetPosition = transform.position;
        targetPosition.x -= (scale.x / 2);
        targetPosition.z += (scale.z / 2);
        if (corners.Length > 2 && corners[2]) corners[2].transform.position = targetPosition;

        targetPosition = transform.position;
        targetPosition.x -= (scale.x / 2);
        targetPosition.z -= (scale.z / 2);
        if (corners.Length > 3 && corners[3]) corners[3].transform.position = targetPosition;

        //SIDES
        targetPosition = transform.position;
        targetPosition.x += scale.x / 2;
        targetScale = Vector3.one;
        targetScale.z = scale.z * cornerFactor;
        if (sides.Length > 0 && sides[0])
        {
            sides[0].transform.position = targetPosition;
            sides[0].transform.localScale = targetScale;
        }

        targetPosition = transform.position;
        targetPosition.x -= scale.x / 2;
        targetScale = Vector3.one;
        targetScale.z = scale.z * cornerFactor;
        if (sides.Length > 1 && sides[1]) 
        { 
            sides[1].transform.position = targetPosition;
            sides[1].transform.localScale = targetScale;
        }

        targetPosition = transform.position;
        targetPosition.z += scale.z / 2;
        targetScale = Vector3.one;
        targetScale.z = scale.x * cornerFactor;
        if (sides.Length > 2 && sides[2])
        {
            sides[2].transform.position = targetPosition;
            sides[2].transform.localScale = targetScale;
        }

        targetPosition = transform.position;
        targetPosition.z -= scale.z / 2;
        targetScale = Vector3.one;
        targetScale.z = scale.x * cornerFactor;
        if (sides.Length > 3 && sides[3])
        {
            sides[3].transform.position = targetPosition;
            sides[3].transform.localScale = targetScale;
        }

        //COLLIDER
        if(collider) collider.size = scale;
    }
}
