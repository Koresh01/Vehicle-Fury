using UnityEngine;

/// <summary>
/// Скрипт по перемещению персонажа.
/// </summary>
public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField] OnFootMap onFootInput;
    CharacterController characterController;
    
    [Header("Камера:")]
    [SerializeField] float mouseSens = 1f;
    [SerializeField] Transform camTransform;
    [SerializeField] float cameraDistance = 1f;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    [Header("Перемещение:")]
    [SerializeField] float moveSpeed = 6f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ApplyMovement();
        UpdateCameraPos();
    }

    void ApplyMovement()
    {
        Vector3 totalMovement;

        Vector3 forward = camTransform.rotation * Vector3.forward;
        Vector3 horizontal = camTransform.rotation * Vector3.right;


        totalMovement = (horizontal * onFootInput.movement.x + forward * onFootInput.movement.y) * moveSpeed * Time.deltaTime;
        totalMovement.y = 0;
        

        characterController.Move(totalMovement);
    }

    void UpdateCameraPos()
    {
        float mouseX = onFootInput.lookDelta.x * Time.deltaTime * mouseSens;
        float mouseY = -onFootInput.lookDelta.y * Time.deltaTime * mouseSens;

        // Накопление горизонтального вращения
        horizontalRotation += mouseX;

        // Накопление и ограничение вертикального вращения
        verticalRotation += mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, 2f, 70f);

        // Создаем итоговый поворот
        Quaternion finalRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);

        // Вычисляем новое направление камеры
        Vector3 newDir = finalRotation * Vector3.forward;

        // Обновляем позицию и поворот камеры
        camTransform.position = transform.position - newDir * cameraDistance;
        camTransform.rotation = Quaternion.LookRotation(newDir);
    }
}
