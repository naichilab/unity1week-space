using System.Xml;
using TargetPlatform;
using UniRx;
using UnityEngine;
using Zenject;
using UniRx.Triggers;

public class DontShowScreenReset : MonoBehaviour
{
    [Inject] private ScreenManager screenManager;

    [Range(0, 100)]
    public float Speed = 10;

    public int SpriteCount = 3;

    private Vector3 spriteSize;

    private void Awake()
    {
        spriteSize = GetComponent<SpriteRenderer>().bounds.size;

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                transform.position += Vector3.down * Speed * Time.deltaTime;
                if (Runtime.Platform.isEditor)
                {
                    var spritey = (transform.position + spriteSize / 2).y;
                    if (spritey < screenManager.screenRect.y)
                    {
                        OnBecameInvisible();
                    }
                }
            });

    }
    
    private void OnBecameInvisible()
    {
        var height = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position += Vector3.up * height * SpriteCount;
    }
}