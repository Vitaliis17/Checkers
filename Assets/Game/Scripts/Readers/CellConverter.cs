using UnityEngine.Tilemaps;
using UnityEngine;
using Zenject;

public class CellConverter : ICellConverter
{
    [Inject] private Tilemap _map;

    public Vector3Int WorldToCell(Vector3 pixelPosition)
        => _map.WorldToCell(pixelPosition);

    public Vector3 CellToWorld(Vector3Int cellPosition)
        => _map.GetCellCenterWorld(cellPosition);
}