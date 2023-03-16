using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LVin.ColorPzl.Core
{
    public static class ColorManager
    {
        public static Color AddColor(Color c1, Color c2)
        {
            float r = c1.r + c2.r;
            float g = c1.g + c2.g;
            float b = c1.b + c2.b;
            r = Mathf.Clamp(r, 0, 1);
            g = Mathf.Clamp(g, 0, 1);
            b = Mathf.Clamp(b, 0, 1);

            return new Color(r, g, b);
        }
        public static Color SubtractColor(Color c1, Color c2)
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
}