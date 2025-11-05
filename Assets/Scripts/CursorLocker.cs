using UnityEngine;

/// <summary>
/// Отвечает за отображение курсора мыши в игре.
/// </summary>
public class CursorLocker : MonoBehaviour
{
    private void Start()
    {
        HideCursor();
    }

    void ShowCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    void HideCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
