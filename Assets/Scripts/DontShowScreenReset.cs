using UnityEngine;
using System.Collections;
public class DontShowScreenReset : MonoBehaviour
{
    [Range(0, 10)]
    public float
        speed = 10;
    public int spriteCount = 3;
    Vector3 spriteSize;
    void Start()
    {
        spriteSize = GetComponent<SpriteRenderer>().bounds.size;
    }
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
#if UNITY_EDITOR
        var spritex = (transform.position + spriteSize / 2).x;
        if (spritex < ScreenManager.Instance.screenRect.x)
        {
            OnBecameInvisible();
        }
#endif
    }
    void OnBecameInvisible()
    {
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        transform.position += Vector3.right * width * spriteCount;
    }
}