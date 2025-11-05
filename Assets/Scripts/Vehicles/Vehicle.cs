using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    /// <summary>
    /// Переключение на управление техникой.
    /// </summary>
    public abstract void EnterVehicle();

    /// <summary>
    /// Переключение на управление персонажем.
    /// </summary>
    public abstract void ExitVehicle();
}
