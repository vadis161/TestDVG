using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static float GetScreenHalfWidthUnit()
    {
        float ratio = (float)Screen.width / (float)Screen.height;
        return Camera.main.orthographicSize * ratio;
    }
}
