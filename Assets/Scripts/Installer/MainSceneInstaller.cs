
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
{
    [SerializeField] private GameStateModel state;
    [SerializeField] private ShipModel ship;
    [SerializeField] private GuageModel guage;
    [SerializeField] private EffectSpawner effectSpawner;

    public override void InstallBindings()
    {
        Container.Bind<ScreenManager>().AsSingle();

        Container.Bind<GameStateModel>().FromInstance(state).AsSingle();
        Container.Bind<ShipModel>().FromInstance(ship).AsSingle();
        Container.Bind<GuageModel>().FromInstance(guage).AsSingle();
        Container.Bind<EffectSpawner>().FromInstance(effectSpawner).AsSingle();
    }
}