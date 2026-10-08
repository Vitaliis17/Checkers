using R3;
using Zenject;
using System;
using UnityEngine;

public class A : IInitializable, IDisposable
{
    [Inject] private IHaveCellPositionEvent _event;
    [Inject] private ICheckerContainer _container;

    private DisposableBag _bag;

    public void Initialize()
    {
        _bag.Add(_event.SelectedCellPosition
            .Where(_ => _container.IsChosedChecker())
            .Subscribe(cellPosition => TranslateChecker(_container.Get(), cellPosition)));

        _bag.Add(_event.SelectedCellPosition
            .Where(_ => _container.IsChosedChecker() == false)
            .Subscribe(cellPosition => _container.Choose(cellPosition)));
    }

    public void Dispose()
        => _bag.Dispose();

    private void TranslateChecker(Checker checker, Vector3Int cellPosition)
    {
        if (_container.IsCellContainChecker(cellPosition))
        {
            //_container.Release(checker);

            return;
        }
    }
}