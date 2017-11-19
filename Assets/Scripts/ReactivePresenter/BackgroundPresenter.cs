using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using UniRx;

public class BackgroundPresenter : MonoBehaviour
{
    private List<BackgroundScroll> rects = new List<BackgroundScroll>();


    [Inject] private ShipModel ship;

    void Awake()
    {
        this.rects = gameObject.GetComponentsInChildren<BackgroundScroll>().ToList();

        //speedを背景スクロールに適用
        ship.BaseSpeed.Subscribe(speed =>
        {
            rects.ForEach(r => r.Speed = speed * speed);
        });
    }

}
