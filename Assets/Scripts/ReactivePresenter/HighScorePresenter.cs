using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using UniRx;

public class HighScorePresenter : MonoBehaviour
{
    private TextMeshProUGUI text;

    [Inject] private ShipModel ship;
    [Inject] private HighscoreModel highScore;
    [Inject] private GameStateModel state;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();

        ship.SpeedToShow.Subscribe(s =>
        {
            highScore.SetScore(s);
        });

        highScore.HighScore.Subscribe(s =>
        {
            text.text = string.Format("{0}km/h", s.ToString("0.00"));
        });

        state.CurrentState.Subscribe(s =>
        {
            if (s == State.Result)
            {
                highScore.SaveHighScore();
            }
        });
    }
}
