using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Ввод от пользователя для управления персонажем.
/// </summary>
public class OnFootMap : Map
{
    InputActions inputActions;

    [SerializeField] Vector2 movement;
    [SerializeField] Vector2 lookDelta;

    public override void InitializeInputActions(InputActions inputActions)
    {
        this.inputActions = inputActions;
    }

    private void OnEnable()
    {
        inputActions.OnFootMap.Enable();

        inputActions.OnFootMap.Move.performed += OnMove;
        inputActions.OnFootMap.Move.canceled += OnMove;

        inputActions.OnFootMap.Look.performed += OnLook;
        inputActions.OnFootMap.Look.canceled += OnLook;
    }

    private void OnDisable()
    {
        inputActions.OnFootMap.Enable();

        inputActions.OnFootMap.Move.performed -= OnMove;
        inputActions.OnFootMap.Move.canceled -= OnMove;

        inputActions.OnFootMap.Look.performed -= OnLook;
        inputActions.OnFootMap.Look.canceled -= OnLook;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        // Применяем движение
    }

    private void OnLook(InputAction.CallbackContext context)
    {
        lookDelta = context.ReadValue<Vector2>();
        // Применяем поворот камеры
    }
}
