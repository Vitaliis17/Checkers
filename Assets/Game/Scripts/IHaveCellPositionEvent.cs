using UnityEngine;
using R3;

public interface IHaveCellPositionEvent
{
    Observable<Vector3Int> SelectedCellPosition { get; }
}