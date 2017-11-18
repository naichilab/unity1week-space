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
    private const int MaxBoostCount = 5;

    //エネルギー消費率
    private const float UseRatio = 0.35f;
    //エネルギー消費に対するスピード増加量
    private const float EnergyToSpeedRatio = 3f;

    [Inject] private GuageModel guage;
    [Inject] private EffectSpawner effectSpawner;

    public FloatReactiveProperty Energy = new FloatReactiveProperty(DefaultEnergy);
    public FloatReactiveProperty BaseSpeed = new FloatReactiveProperty(DefaultSpeed);
    public FloatReactiveProperty SpeedToShow = new FloatReactiveProperty(DefaultSpeed);

    public IntReactiveProperty RemainBoostCount = new IntReactiveProperty(0);
    public BoolReactiveProperty CanBoost = new BoolReactiveProperty();

    public BoolReactiveProperty IsAccelerating = new BoolReactiveProperty(false);

    public BoolReactiveProperty IsGameOver = new BoolReactiveProperty();

    private void Awake()
    {
        Energy.Subscribe(e =>
        {
            IsAccelerating.Value = Energy.Value > 0f;
        });

        RemainBoostCount.Subscribe(c =>
        {
            CanBoost.Value = c > 0;
        });

        BaseSpeed.Subscribe(s =>
        {
            SpeedToShow.Value = s * s * 60 * 60;
        });

        //加速
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                if (this.Energy.Value >= 0f)
                {
                    float useEnergy = Mathf.Min(Time.deltaTime * UseRatio, this.Energy.Value);

                    this.BaseSpeed.Value += useEnergy * EnergyToSpeedRatio;
                    this.Energy.Value -= useEnergy;
                }
            });

        //ゲームオーバー判定
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                if (!CanBoost.Value && Energy.Value <= 0f)
                {
                    //燃料切れ＆加速終了
                    this.IsGameOver.Value = true;
                }
            });
    }


    public void Clear()
    {
        this.Energy.Value = DefaultEnergy;
        this.BaseSpeed.Value = DefaultSpeed;
        this.RemainBoostCount.Value = MaxBoostCount;
        this.IsGameOver.Value = false;
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
        if (CanBoost.Value)
        {
            RemainBoostCount.Value--;

            var energy = guage.Power.Value;

            EffectSpawner.EffectType effect = EffectSpawner.EffectType.miss;
            if (energy < GuageModel.GreatPowerThrethold) effect = EffectSpawner.EffectType.good;
            else if (energy < GuageModel.PerfectPowerThrethold) effect = EffectSpawner.EffectType.great;
            else if (energy < GuageModel.BrokenPowerThrethold) effect = EffectSpawner.EffectType.perfect;

            //エフェクト表示
            effectSpawner.Show(effect);

            if (effect == EffectSpawner.EffectType.miss)
            {

            }
            else
            {
                //加速
                AddEnergy(energy);
                guage.Init();

            }
        }
    }



}
