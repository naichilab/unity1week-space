using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

public class BoostPresenter : MonoBehaviour
{

    [Inject] private ShipModel ship;

    private Image boost;

    private void Awake()
    {
        boost = GetComponent<Image>();
        boost.enabled = false;

        ship.IsAccelerating.Subscribe(acc =>
        {
            boost.enabled = acc;
        });
    }
}
