using UnityEngine;

public interface ICheckerContainer
{
    bool IsChosedChecker();

    bool IsCellContainChecker(Vector3Int checkerPosition);

    void Choose(Vector3Int cellPosition);

    void Release(Checker checker, Vector3Int cellPosition);

    Checker Get();
}