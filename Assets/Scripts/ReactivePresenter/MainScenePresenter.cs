using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class MainScenePresenter : MonoBehaviour
{
    [Inject] private GameManager gameManager;
    [Inject] private GameModel model;

    [Inject(Id = "GOBUTTON")] private Button goButton;
    [Inject(Id = "GUAGE_BACK")] private Image guageBackImage;
    [Inject(Id = "GUAGE_FRONT")] private Image guageFrontImage;
    [Inject(Id = "GUAGE_FRAME")] private Image guageFrameImage;
    [Inject(Id = "TITLE_LOGO")] private Image titleLogoImage;


    private bool GuageVisible
    {
        get { return guageFrameImage.enabled; }
        set
        {
            guageBackImage.enabled = value;
            guageFrontImage.enabled = value;
            guageFrameImage.enabled = value;
        }
    }

    private void Awake()
    {
        GuageVisible = false;

        goButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                model.Go();
            });

        model.State.Subscribe(state =>
        {
            switch (state)
            {
                case State.Title:
                    GuageVisible = false;
                    titleLogoImage.enabled = true;
                    break;
                case State.GamePlay:
                    GuageVisible = true;
                    titleLogoImage.enabled = false;
                    break;
                case State.Result:
                    break;
                default:
                    throw new NotImplementedException();
            }
        });

        model.Power.Subscribe(power =>
        {
            guageFrontImage.fillAmount = Mathf.Clamp01(power);
        });
    }



}
