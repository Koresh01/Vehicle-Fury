using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Ввод от пользователя для управления автомобилем.
/// </summary>
public class CarMap : Map
{
    public InputActions inputActions;


    [SerializeField] float steering;
    [SerializeField] float throttle;



    public override void InitializeInputActions(InputActions inputActions)
    {
        this.inputActions = inputActions;
    }

    private void OnEnable()
    {
        inputActions.CarMap.Enable();

        inputActions.CarMap.Steering.performed += OnSteering;
        inputActions.CarMap.Steering.canceled += OnSteering;

        inputActions.CarMap.Throttle.performed += OnThrottle;
        inputActions.CarMap.Throttle.canceled += OnThrottle;
    }
    private void OnDisable()
    {
        inputActions.CarMap.Disable();

        inputActions.CarMap.Steering.performed -= OnSteering;
        inputActions.CarMap.Steering.canceled -= OnSteering;

        inputActions.CarMap.Throttle.performed -= OnThrottle;
        inputActions.CarMap.Throttle.canceled -= OnThrottle;
    }

    private void OnSteering(InputAction.CallbackContext context)
    {
        steering = context.ReadValue<float>();
        // Применяем руление
    }

    private void OnThrottle(InputAction.CallbackContext context)
    {
        throttle = context.ReadValue<float>();
        // Применяем газ
    }

    
}
