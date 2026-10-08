using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CheckersContainer : ICheckerContainer
{
    private readonly Dictionary<Vector3Int, Checker> _checkers;

    private Vector3Int _lastChosedChecker;

    [Inject]
    public CheckersContainer(Checker[] checkers, Vector3Int[] checkerPositions)
    {
        _checkers = new Dictionary<Vector3Int, Checker>(checkers.Length);

        for (int i = 0; i < checkers.Length; i++)
            _checkers.Add(checkerPositions[i], checkers[i]);
    }

    public bool IsChosedChecker()
        => _lastChosedChecker != null;

    public bool IsCellContainChecker(Vector3Int checkerPosition)
        => _checkers.ContainsKey(checkerPosition);

    public void Choose(Vector3Int cellPosition)
    {
        if (IsCellContainChecker(cellPosition) == false)
            return;

        _lastChosedChecker = cellPosition;
    }

    public Checker Get()
        => _checkers[_lastChosedChecker];

    public void Release(Checker checker, Vector3Int cellPosition)
    {
        if (IsCellContainChecker(cellPosition))
            return;

        _checkers.Add(cellPosition, checker);
        //_lastChosedChecker.;
    }


}