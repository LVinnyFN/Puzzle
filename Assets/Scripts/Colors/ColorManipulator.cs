using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LVin.ColorPzl.Core
{
    public class ColorManipulator : MonoBehaviour
    {
        [SerializeField] protected Color manipulatedColor;
        [SerializeField] protected Renderer[] coloredObjects;

        private void Awake()
        {
            SetOwnColor(manipulatedColor);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = manipulatedColor;
            foreach (Renderer obj in coloredObjects)
            {
                Gizmos.DrawWireMesh(obj.GetComponent<MeshFilter>().sharedMesh, obj.transform.position, obj.transform.rotation, obj.transform.localScale);
            }
        }

        private void SetOwnColor(Color color)
        {
            foreach (Renderer renderer in coloredObjects)
            {
                renderer.material.color = color;
            }
        }
    }
}