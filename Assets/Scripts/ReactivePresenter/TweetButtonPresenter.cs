using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class TweetButtonPresenter : MonoBehaviour
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
                var msg = string.Format("{0}km/s まで加速しました。世界最速を目指せ！", ship.SpeedToShow.Value.ToString("0.00"));
                naichilab.UnityRoomTweet.Tweet("go-go-rocket", msg, "GoGoRocket", "unity1week");
            });

        state.CurrentState.Subscribe(s =>
        {
            image.enabled = s == State.Result;
        });
    }

}
