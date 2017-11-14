using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScoreTextPresenter : MonoBehaviour
{
    private Text scoreText;

    [Inject] private GameData gameData;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
        gameData.Score.Subscribe(s => scoreText.text = s.ToString());
    }
}
