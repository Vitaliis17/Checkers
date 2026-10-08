using UnityEngine;

public interface ICellConverter
{
    Vector3Int WorldToCell(Vector3 pixelPosition);

    Vector3 CellToWorld(Vector3Int cellPosition);
}