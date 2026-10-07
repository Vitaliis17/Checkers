using System;
using UnityEngine;
using Zenject;
using R3;

public class Presenter : IInitializable, IDisposable
{
    [Inject] private IHaveMouseEvent _event;

    [Inject] private ICellConverter _cellConverter;
    [Inject] private IRayConverter _rayConverter;

    private Checker _checker;

    private IDisposable _disposable;

    public void Initialize()
    {
        _disposable = _event.PositionChanged
            .Subscribe(pixelPosition => A(pixelPosition));
    }

    public void Dispose()
        => _disposable?.Dispose();

    private void A(Vector2 pixelPosition)
    {
        Ray ray = _rayConverter.ScreenPointToCell(pixelPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) == false)
            return;

        if (_checker != null)
        {
            Vector3Int cellPosition = _cellConverter.WorldToCell(hit.point);

            _checker.transform.position = _cellConverter.CellToWorld(cellPosition);
            _checker = null;

            return;
        }

        if (hit.transform.TryGetComponent(out Checker checker))
        {
            _checker = checker;
        }
    }
}