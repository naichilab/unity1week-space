using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class GuageModel : MonoBehaviour
{
    /// <summary>
    /// 赤エリア
    /// </summary>
    public static float BrokenPowerThrethold = 0.88f;

    public static float PerfectPowerThrethold = 0.85f;

    public static float GreatPowerThrethold = 0.75f;

    /// <summary>
    /// ゲージ基本速度
    /// </summary>
    private const float TimeToFull = 3f;

    [Inject] private GameStateModel state;
    [Inject] private ShipModel ship;

    public FloatReactiveProperty Power = new FloatReactiveProperty(0f);

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
        this.Power.Value = 0f;
    }
}
