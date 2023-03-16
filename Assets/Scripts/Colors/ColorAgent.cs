using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LVin.ColorPzl.Core
{
    public class ColorAgent : MonoBehaviour
    {
        [SerializeField] private Color color;
        [SerializeField] private Renderer render;
        public Color MyColor => color;

        private void Awake()
        {
            SetColor(color);
        }

        public void AddColor(Color color)
        {
            this.color = ColorManager.AddColor(this.color, color);
            render.material.color = this.color;
        }
        public void SubtractColor(Color color)
        {
            this.color = ColorManager.SubtractColor(this.color, color);
            render.material.color = this.color;
        }

        public void SetColor(Color color)
        {
            this.color = color;
            render.material.color = this.color;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = color;
            Gizmos.DrawWireMesh(render.GetComponent<MeshFilter>().sharedMesh, render.transform.position, render.transform.rotation, render.transform.localScale);
        }
    }
}