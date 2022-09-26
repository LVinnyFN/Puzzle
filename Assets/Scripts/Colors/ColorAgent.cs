using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAgent : MonoBehaviour
{
    [SerializeField] private Color color;
    [SerializeField] private Material material;
    public Color MyColor { get { return color; } set { color = value; material.color = color; }}

    private void Awake()
    {
        SetColor(color);
    }
    private void OnValidate()
    {
        SetColor(color);
    }

    public void AddColor(Color color)
    {
        MyColor = ColorManager.Instance.AddColor(this.color, color);
    }
    public void SubtractColor(Color color)
    {
        MyColor = ColorManager.Instance.SubtractColor(this.color, color);
    }

    public void SetColor(Color color)
    {
        MyColor = color;
    }    
}
