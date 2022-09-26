using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }
    public Color AddColor(Color c1, Color c2)
    {
        float r = c1.r + c2.r;
        float g = c1.g + c2.g;
        float b = c1.b + c2.b;
        r = Mathf.Clamp(r, 0, 1);
        g = Mathf.Clamp(g, 0, 1);
        b = Mathf.Clamp(b, 0, 1);

        return new Color(r, g, b);
    }
    public Color SubtractColor(Color c1, Color c2)
    {
        float r = c1.r - c2.r;
        float g = c1.g - c2.g;
        float b = c1.b - c2.b;
        r = Mathf.Clamp(r, 0, 1);
        g = Mathf.Clamp(g, 0, 1);
        b = Mathf.Clamp(b, 0, 1);

        return new Color(r, g, b);
    }
}
