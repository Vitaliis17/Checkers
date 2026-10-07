using UnityEngine;

public interface IRayConverter
{
    Ray ScreenPointToCell(Vector3 pixelPosition);
}