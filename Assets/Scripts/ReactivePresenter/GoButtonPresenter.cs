using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class GoButtonPresenter : MonoBehaviour
{
    private Button go;

    [Inject] private GameStateModel state;

    [Inject] private ShipModel ship;

    private void Awake()
    {
        go = GetComponent<Button>();


        //ゲーム開始＆リトライ
        go.OnClickAsObservable()
            .Subscribe(_ =>
            {
                if (state.CurrentStateIsTitle)
                {
                    state.ChangeToGamePlayState();
                }
                else if (state.CurrentStateIsResult)
                {
                    state.ChangeToGamePlayState();
                }
            });

        //加速
        go.OnPointerDownAsObservable()
            .Subscribe(_ =>
            {
                if (state.CurrentStateIsGamePlay)
                {
                    ship.Boost();
                }
            });

        //燃料切れ
        ship.CanBoost.Subscribe(c =>
        {
            if (state.CurrentStateIsGamePlay)
            {
                go.interactable = c;
            }
        });

        state.CurrentState.Subscribe(s =>
        {
            if (s == State.Result)
            {
                go.interactable = true;
            }
        });

    }

}
