using UnityEngine;
using Zenject;

public class ScreenManagerInstaller : MonoInstaller<ScreenManagerInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ScreenManager>().AsSingle();

    }
}