using System;
using UnityEngine;
using Zenject;
using R3;

public class CheckerTranslater : IInitializable, IDisposable, IHaveCellPositionEvent
{
    [Inject] private IHaveMouseEvent _event;

    [Inject] private ICellConverter _cellConverter;
    [Inject] private IRayConverter _rayConverter;

    private IDisposable _disposable;

    private Subject<Vector3Int> _selectedCellPosition;

    public Observable<Vector3Int> SelectedCellPosition => _selectedCellPosition;

    public void Initialize()
    {
        _selectedCellPosition = new();

        _disposable = _event.PositionChanged
            .Subscribe(pixelPosition => Translate(pixelPosition));
    }

    public void Dispose()
    {
        _disposable?.Dispose();
        _selectedCellPosition?.Dispose();
    }

    private void Translate(Vector2 pixelPosition)
    {
        Ray ray = _rayConverter.ScreenPointToCell(pixelPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) == false)
            return;

        Vector3Int cellPosition = _cellConverter.WorldToCell(hit.point);

        _selectedCellPosition.OnNext(cellPosition);
    }
}