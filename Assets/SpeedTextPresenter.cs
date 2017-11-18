using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using UniRx;

public class SpeedTextPresenter : MonoBehaviour
{
    private TextMeshProUGUI text;

    [Inject] private ShipModel ship;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        ship.SpeedToShow.Subscribe(s =>
        {
            text.text = string.Format("{0}km/h", s.ToString("0.00"));
        });
    }
}
