using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using UnityEngine.UI;

public class TitleLogoPresenter : MonoBehaviour
{
    private Image image;

    [Inject] private GameStateModel state;

    private void Awake()
    {
        image = GetComponent<Image>();

        state.CurrentState.Subscribe(currentState =>
        {
            image.enabled = currentState == State.Title;
        });
    }
}
