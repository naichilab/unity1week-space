using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class GameModel : MonoBehaviour
{
    public StateReactiveProperty State = new StateReactiveProperty(global::State.Title);

    private float TimeToFull = 3f;
    public FloatReactiveProperty Power = new FloatReactiveProperty(0f);


    [Inject] private ShipModel ship;

    private bool IsTitle { get { return this.State.Value == global::State.Title; } }
    private bool IsGamePlay { get { return this.State.Value == global::State.GamePlay; } }
    private bool IsResult { get { return this.State.Value == global::State.Result; } }

    private void GameStart()
    {
        if (!IsTitle) return;
        this.TimeToFull = 3f;
        this.ship.Clear();
        this.Power.Value = 0f;
        this.State.Value = global::State.GamePlay;
    }

    public void Go()
    {
        if (IsTitle)
        {
            this.GameStart();
        }
        else if (IsGamePlay)
        {
            this.ship.AddEnergy(Power.Value);
            Power.Value = 0;
        }
    }
    private void Update()
    {
        if (IsGamePlay)
        {
            this.Power.Value += Time.deltaTime / TimeToFull;
            if (this.Power.Value >= 1f)
            {
                this.Power.Value -= 1f;
            }

        }
    }
}
