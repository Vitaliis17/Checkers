using UnityEngine.InputSystem;
using UnityEngine;
using Zenject;
using R3;

public class MouseReader : IHaveMouseEvent, IInitializable
{
    private Action.GameplayActions _action;

    public Observable<Vector2> PositionChanged { get; private set; }

    public void Initialize()
    {
        _action = new Action().Gameplay;
        _action.Enable();

        PositionChanged = Observable.FromEvent<InputAction.CallbackContext>(
            h => _action.Mouse.performed += h,
            h => _action.Mouse.performed -= h
        ).Select(_ => Mouse.current.position.ReadValue());
    }
}
