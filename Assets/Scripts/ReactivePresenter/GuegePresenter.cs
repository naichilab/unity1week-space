using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

public class GuegePresenter : MonoBehaviour
{

    [SerializeField] private Image back;
    [SerializeField] private Image front;
    [SerializeField] private Image frame;

    [Inject] private GameStateModel state;
    [Inject] private GuageModel guage;
    [Inject] private ShipModel ship;


    private void Awake()
    {
        state.CurrentState.Subscribe(s =>
        {
            back.enabled = s == State.GamePlay;
            front.enabled = s == State.GamePlay;
            frame.enabled = s == State.GamePlay;
        });

        ship.CanBoost.Subscribe(c =>
        {
            back.enabled = (state.CurrentStateIsGamePlay) && c;
            front.enabled = (state.CurrentStateIsGamePlay) && c;
            frame.enabled = (state.CurrentStateIsGamePlay) && c;
        });

        guage.Power.Subscribe(power =>
        {
            front.fillAmount = Mathf.Clamp01(power);
        });


    }
}
