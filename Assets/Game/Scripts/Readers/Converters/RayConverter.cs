using UnityEngine;
using Zenject;

public class RayConverter : IRayConverter
{
    [Inject] private Camera _camera;

    public Ray ScreenPointToCell(Vector3 pixelPosition)
        => _camera.ScreenPointToRay(pixelPosition);
}