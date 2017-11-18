using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using UniRx;

public class BackgroundPresenter : MonoBehaviour
{
    private List<DontShowScreenReset> rects = new List<DontShowScreenReset>();


    [Inject] private ShipModel ship;

    void Awake()
    {
        this.rects = gameObject.GetComponentsInChildren<DontShowScreenReset>().ToList();

        //speedを背景スクロールに適用
        ship.Speed.Subscribe(speed =>
        {
            rects.ForEach(r => r.Speed = speed);
        });
    }
    
}
