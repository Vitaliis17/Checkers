using UnityEngine;
using R3;

public interface IHaveMouseEvent
{
    Observable<Vector2> PositionChanged { get; }
}