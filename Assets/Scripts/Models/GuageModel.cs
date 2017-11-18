using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class GuageModel : MonoBehaviour
{
    [Inject] private GameStateModel state;
    [Inject] private ShipModel ship;

    private float TimeToFull = 3f;

    public FloatReactiveProperty Power = new FloatReactiveProperty(0f);

    public BoolReactiveProperty Visible = new BoolReactiveProperty(false);

    private void Update()
    {
        if (!state.CurrentStateIsGamePlay) return;

        var guageSpeed = (Time.deltaTime / TimeToFull) * ship.BaseSpeed.Value;
        var minSpeed = (Time.deltaTime / TimeToFull) * 1;
        var maxSpeed = (Time.deltaTime / TimeToFull) * 5;
        Power.Value += Mathf.Clamp(guageSpeed, minSpeed, maxSpeed);
        if (Power.Value >= 1f)
        {
            Power.Value -= 1f;
        }
    }

    public void Init()
    {
        this.TimeToFull = 3f;
        this.Power.Value = 0f;
    }

    public void Show()
    {
        this.Visible.Value = true;
    }
    public void Hide()
    {
        this.Visible.Value = false;
    }


}
