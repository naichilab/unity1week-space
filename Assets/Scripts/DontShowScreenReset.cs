using System.Xml;
using UnityEngine;
using Zenject;

public class DontShowScreenReset : MonoBehaviour
{
    [Inject] private ScreenManager screenManager;

    [Range(0, 100)]
    public float Speed = 10;
    public int SpriteCount = 3;

    private Vector3 spriteSize;

    private void Start()
    {
        spriteSize = GetComponent<SpriteRenderer>().bounds.size;
    }

    private void Update()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
#if UNITY_EDITOR
        var spritey = (transform.position + spriteSize / 2).y;
        if (spritey < screenManager.screenRect.y)
        {
            OnBecameInvisible();
        }
#endif
    }

    private void OnBecameInvisible()
    {
        var height = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position += Vector3.up * height * SpriteCount;
    }
}