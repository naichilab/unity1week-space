using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ShipModel : MonoBehaviour
{
    public FloatReactiveProperty Energy = new FloatReactiveProperty(0f);
    public FloatReactiveProperty Speed = new FloatReactiveProperty(1f);

    private void Update()
    {
        if (this.Energy.Value >= 0f)
        {
            float useEnergy = Mathf.Min(Time.deltaTime, this.Energy.Value);

            this.Speed.Value += useEnergy;
            this.Energy.Value -= useEnergy;
        }
    }

    public void Clear()
    {
        this.Energy.Value = 0f;
        this.Speed.Value = 1f;
    }

    public void AddEnergy(float energy)
    {
        this.Energy.Value += energy;
    }




}
