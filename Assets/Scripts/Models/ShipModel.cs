using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class ShipModel : MonoBehaviour
{
    private const float DefaultEnergy = 0f;
    private const float DefaultSpeed = 0f;

    //エネルギー消費率
    private const float UseRatio = 0.2f;
    //エネルギー消費に対するスピード増加量
    private const float EnergyToSpeedRatio = 3f;

    [Inject] private GuageModel guage;

    public FloatReactiveProperty Energy = new FloatReactiveProperty(DefaultEnergy);
    public FloatReactiveProperty BaseSpeed = new FloatReactiveProperty(DefaultSpeed);
    public FloatReactiveProperty SpeedToShow = new FloatReactiveProperty(DefaultSpeed);

    public BoolReactiveProperty IsAccelerating = new BoolReactiveProperty(false);

    private void Awake()
    {
        Energy.Subscribe(e =>
        {
            IsAccelerating.Value = Energy.Value > 0f;
        });
    }

    private void Update()
    {
        SpeedToShow.Value = BaseSpeed.Value * BaseSpeed.Value;

        if (this.Energy.Value >= 0f)
        {
            float useEnergy = Mathf.Min(Time.deltaTime * UseRatio, this.Energy.Value);

            this.BaseSpeed.Value += useEnergy * EnergyToSpeedRatio;
            this.Energy.Value -= useEnergy;
        }
    }

    public void Clear()
    {
        this.Energy.Value = DefaultEnergy;
        this.BaseSpeed.Value = DefaultSpeed;
    }

    public void AddEnergy(float energy)
    {
        this.Energy.Value += energy;
    }


    /// <summary>
    /// ゲージのパワーに応じて、燃料を供給する。= Boostを開始する
    /// </summary>
    public void Boost()
    {
        AddEnergy(guage.Power.Value);
        guage.Init();
    }



}
