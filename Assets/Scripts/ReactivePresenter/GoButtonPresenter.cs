using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class GoButtonPresenter : MonoBehaviour
{
    private Button go;

    [Inject] private GameStateModel state;

    [Inject] private ShipModel ship;

    private void Awake()
    {
        go = GetComponent<Button>();

        go.OnClickAsObservable()
            .Subscribe(_ =>
            {
                if (state.CurrentStateIsTitle)
                {
                    state.ChangeToGamePlayState();
                }
            });

        go.OnPointerDownAsObservable()
            .Subscribe(_ =>
            {
                if (state.CurrentStateIsGamePlay)
                {
                    ship.Boost();
                }
            });
    }

}
