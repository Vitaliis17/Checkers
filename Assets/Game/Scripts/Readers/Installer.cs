using UnityEngine.Tilemaps;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private Tilemap _map;
    [SerializeField] private Camera _mainCamera;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<MouseReader>().AsSingle();
        Container.BindInterfacesTo<CheckerTranslater>().AsSingle();

        Container.Bind<Tilemap>().FromInstance(_map).AsSingle();
        Container.Bind<Camera>().FromInstance(_mainCamera).AsSingle();

        Container.Bind<IRayConverter>().To<RayConverter>().AsSingle();
        Container.Bind<ICellConverter>().To<CellConverter>().AsSingle();
    }
}