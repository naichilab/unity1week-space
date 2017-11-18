using UnityEngine;
using System.Collections;
public class ScreenManager
{
    public Rect screenRect;
    public ScreenManager()
    {
        Vector3 tl = Camera.main.ViewportToWorldPoint(Vector3.zero + Vector3.forward * 10);
        Vector3 rd = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0) + Vector3.forward * 10);
        screenRect.x = tl.x;
        screenRect.y = tl.y;
        screenRect.width = (rd - tl).x;
        screenRect.height = (rd - tl).y;
    }
}