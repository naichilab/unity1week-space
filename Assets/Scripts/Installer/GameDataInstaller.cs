using UnityEngine;
using Zenject;

public class GameDataInstaller : MonoInstaller<GameDataInstaller>
{
    [SerializeField] private GameData gameData;

    public override void InstallBindings()
    {
        Container.Bind<GameData>().FromInstance(gameData).AsSingle();
    }
}