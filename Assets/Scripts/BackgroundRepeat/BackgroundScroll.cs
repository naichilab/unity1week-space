using System.Xml;
using TargetPlatform;
using UniRx;
using UnityEngine;
using Zenject;
using UniRx.Triggers;

public class BackgroundScroll : MonoBehaviour
{
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

                if (transform.position.y < -spriteSize.y)
                {
                    transform.position += Vector3.up * spriteSize.y * 2;
                }
            });

    }
    
}