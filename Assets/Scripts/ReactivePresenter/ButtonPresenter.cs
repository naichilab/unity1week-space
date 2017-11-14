using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;

public class ButtonPresenter : MonoBehaviour
{
    private Button centerButton;

    [Inject] private GameData gameData;

    private void Awake()
    {
        centerButton = GetComponent<Button>();

        centerButton.OnClickAsObservable()
            .Subscribe(_ =>
            {
                gameData.Score.Value = gameData.Score.Value + 1;
            });
    }
}
