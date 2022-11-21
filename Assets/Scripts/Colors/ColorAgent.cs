using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAgent : MonoBehaviour
{
    [SerializeField] private Color color;
    [SerializeField] private Renderer rend;
    public Color MyColor => color;

    private void Awake()
    {
        SetColor(color);
    }

    public void AddColor(Color color)
    {
        this.color = ColorManager.AddColor(this.color, color);
        rend.material.color = this.color;
    }
    public void SubtractColor(Color color)
    {
        this.color = ColorManager.SubtractColor(this.color, color);
        rend.material.color = this.color;
    }

    public void SetColor(Color color)
    {
        this.color = color;
        rend.material.color = this.color;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawWireMesh(rend.GetComponent<MeshFilter>().sharedMesh, rend.transform.position, rend.transform.rotation, rend.transform.localScale);        
    }
}
