using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

public class HighscoreModel : MonoBehaviour
{
    private const string KEY = "HIGHSCORE";

    public FloatReactiveProperty HighScore = new FloatReactiveProperty();


    private void Awake()
    {
        float highScore = PlayerPrefs.GetFloat(KEY, 0f);

        this.HighScore.Value = highScore;
    }

    public void SetScore(float score)
    {
        if (HighScore.Value < score)
        {
            HighScore.Value = score;
        }
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetFloat(KEY, HighScore.Value);
        PlayerPrefs.Save();
    }
}
