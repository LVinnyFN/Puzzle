using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LVin.ColorPzl.Core
{
    public class ColorDoor : ColorAgent
    {
        public GameObject doorFrame;
        public Vector3 closedSpot, openOffset;
        private bool isOpen;
        private bool isMoving;
        [Range(0, 1)] public float openPercentage;
        [Min(0)] public float openingDuration;

        public Coroutine movingCoroutine;

        public void SetState(bool state)
        {
            if (state) Open();
            else Close();
        }

        [ContextMenu("Open")]
        public void Open()
        {
            if (movingCoroutine != null) StopCoroutine(movingCoroutine);
            movingCoroutine = StartCoroutine(OpenCoroutine());
        }
        [ContextMenu("Close")]
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
            SetDoor();
        }
    }
}
