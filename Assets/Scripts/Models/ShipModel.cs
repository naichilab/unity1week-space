using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class ShipModel : MonoBehaviour
{
    //エネルギー消費率
    private const float UseRatio = 0.2f;
    //エネルギー消費に対するスピード増加量
    private const float EnergyToSpeedRatio = 5f;

    [Inject] private GuageModel guage;

    public FloatReactiveProperty Energy = new FloatReactiveProperty(0f);
    public FloatReactiveProperty BaseSpeed = new FloatReactiveProperty(1f);
    public FloatReactiveProperty SpeedToShow = new FloatReactiveProperty(1f);

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
        this.Energy.Value = 0f;
        this.BaseSpeed.Value = 1f;
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
