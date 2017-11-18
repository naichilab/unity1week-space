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

    [Inject] private GuageModel guage;


    private void Awake()
    {
        guage.Visible.Subscribe(value =>
        {
            back.enabled = value;
            front.enabled = value;
            frame.enabled = value;
        });

        guage.Power.Subscribe(power =>
        {
            front.fillAmount = Mathf.Clamp01(power);
        });

    }
}
