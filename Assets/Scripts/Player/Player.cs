using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputActions inputActions;


    InputAction moveAction;
    InputAction lookAction;
    InputAction jumpAction;


    [SerializeField] Vector2 movement;
    [SerializeField] Vector2 lookDelta;


    private void Awake()
    {
        inputActions = new InputActions();

        moveAction = inputActions.CharacterMap.Move;
        lookAction = inputActions.CharacterMap.Look;
        jumpAction = inputActions.CharacterMap.Jump;
    }


    private void OnEnable()
    {
        // ВКЛЮЧАЕМ действия и карту действий!
        // inputActions.CharacterMap.Enable();

        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        lookAction.performed += OnLook;
    }

    private void OnDisable()
    {
        // ВЫКЛЮЧАЕМ когда не нужно
        // inputActions.CharacterMap.Disable();

        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
        lookAction.performed -= OnLook;
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
