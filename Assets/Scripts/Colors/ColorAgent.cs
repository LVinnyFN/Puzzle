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
    protected virtual void OnValidate()
    {
        try
        {
            Material material = new Material(rend.sharedMaterial);
            material.color = color;
            rend.material = material;
        }
        catch { }
    }

    public void AddColor(Color color)
    {
        this.color = ColorManager.Instance.AddColor(this.color, color);
        rend.sharedMaterial.color = this.color;
    }
    public void SubtractColor(Color color)
    {
        this.color = ColorManager.Instance.SubtractColor(this.color, color);
        rend.sharedMaterial.color = this.color;
    }

    public void SetColor(Color color)
    {
        this.color = color;
        rend.sharedMaterial.color = this.color;
    }    
}
