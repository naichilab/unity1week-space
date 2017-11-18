using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using UniRx;

public class BoostCountPresenter : MonoBehaviour
{
    private TextMeshProUGUI text;

    [Inject] private GameStateModel state;
    [Inject] private ShipModel ship;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        state.CurrentState.Subscribe(s =>
        {
            text.enabled = s == State.GamePlay;
        });

        ship.RemainBoostCount.Subscribe(c =>
        {
            text.text = string.Format("残り{0}回", c);
        });
    }
}
