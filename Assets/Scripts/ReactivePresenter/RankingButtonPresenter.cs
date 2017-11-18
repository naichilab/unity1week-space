using System.Collections;
using System.Collections.Generic;
using naichilab;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class RankingButtonPresenter : MonoBehaviour
{
    private Button button;
    private Image image;

    [Inject] private GameStateModel state;

    [Inject] private ShipModel ship;

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();

        //ランキング表示
        button.OnClickAsObservable()
            .Subscribe(_ =>
            {
                RankingLoader.Instance.SendScoreAndShowRanking(ship.SpeedToShow.Value);
            });
        
        state.CurrentState.Subscribe(s =>
        {
            image.enabled = s == State.Result;
        });
    }

}
