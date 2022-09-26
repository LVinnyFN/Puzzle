using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDoor : MonoBehaviour
{
    public GameObject doorFrame;
    public Vector3 closedSpot, openOffset;
    public bool isOpen;
    public bool isMoving;
    public float openPercentage;
    public float openingDuration;

    public Coroutine movingCoroutine;

    public void Open()
    {
        if(movingCoroutine != null) StopCoroutine(movingCoroutine);
        movingCoroutine = StartCoroutine(OpenCoroutine());
    }
    public void Close()
    {
        if (movingCoroutine != null) StopCoroutine(movingCoroutine);
        movingCoroutine = StartCoroutine(CloseCoroutine());
    }

    private IEnumerator OpenCoroutine()
    {
        float counter = openingDuration * openPercentage;
        isMoving = true;
        while (counter < openingDuration)
        {
            counter += Time.deltaTime;
            openPercentage = counter / openingDuration;
            SetDoor();
            yield return null;
        }
        openPercentage = Mathf.Min(openPercentage, 1);
        isMoving = false;
        isOpen = true;
    }

    private IEnumerator CloseCoroutine()
    {
        float counter = openingDuration * openPercentage;
        isMoving = true;
        while (counter > 0)
        {
            counter -= Time.deltaTime;
            openPercentage = counter / openingDuration;
            SetDoor();
            yield return null;
        }
        openPercentage = Mathf.Max(openPercentage, 0);
        isMoving = false;
        isOpen = false;
    }

    private void SetDoor()
    {
        doorFrame.transform.localPosition = Vector3.Lerp(closedSpot, closedSpot + openOffset, openPercentage);
    }

    private void OnValidate()
    {
        doorFrame.transform.localPosition = isOpen ? closedSpot + openOffset : closedSpot;
    }
}
