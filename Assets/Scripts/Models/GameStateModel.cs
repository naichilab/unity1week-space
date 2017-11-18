using System;
using System.Collections;
using System.Collections.Generic;
using naichilab;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class GameStateModel : MonoBehaviour
{
    public StateReactiveProperty CurrentState = new StateReactiveProperty(global::State.Title);

    [Inject] private ShipModel ship;
    [Inject] private GuageModel guage;
    [Inject] private HighscoreModel highScore;

    public bool CurrentStateIsTitle { get { return CurrentState.Value == global::State.Title; } }
    public bool CurrentStateIsGamePlay { get { return CurrentState.Value == global::State.GamePlay; } }
    public bool CurrentStateIsResult { get { return CurrentState.Value == global::State.Result; } }

    private void Awake()
    {
        ship.Clear();

        ship.IsGameOver
            .Delay(TimeSpan.FromSeconds(2))
            .Subscribe(c =>
        {
            if (this.CurrentStateIsGamePlay && c)
            {
                CurrentState.Value = global::State.Result;
            }
        });

    }

    private void GameStart()
    {
        ship.Clear();
        guage.Init();

        CurrentState.Value = global::State.GamePlay;
    }

    public void ChangeToGamePlayState()
    {
        if (CurrentStateIsTitle || CurrentStateIsResult)
        {
            GameStart();
        }
    }

}
