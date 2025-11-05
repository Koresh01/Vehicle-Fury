using UnityEngine;

public abstract class Map : MonoBehaviour
{
    /// <summary>
    /// Инициализирует new InputSystem.
    /// </summary>
    /// <param name="inputActions">Глобальные бинды клавиш ввода.</param>
    public abstract void InitializeInputActions(InputActions inputActions);
}