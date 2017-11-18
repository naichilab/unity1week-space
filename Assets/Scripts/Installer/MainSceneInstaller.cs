
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
{
    [SerializeField] private GameModel gameModel;
    [SerializeField] private ShipModel shipModel;
    [SerializeField] private GameManager gameManager;

    public override void InstallBindings()
    {
        Container.Bind<ScreenManager>().AsSingle();
        Container.Bind<GameModel>().FromInstance(gameModel).AsSingle();
        Container.Bind<ShipModel>().FromInstance(shipModel).AsSingle();
        Container.Bind<GameManager>().FromInstance(gameManager).AsSingle();
    }
}