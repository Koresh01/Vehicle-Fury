using Unity.Netcode;
using UnityEngine;

/// <summary>
/// Скрипт по перемещению персонажа.
/// </summary>
public class PlayerLocomotion : NetworkBehaviour
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
    [SerializeField] bool isGrounded;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float gravity = 9.8f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!IsOwner) return;

        ApplyMovement();
        ApplyRotation();
        ApplyGravity();

        UpdateCameraPos();
    }

    void ApplyRotation()
    {
        Vector3 totalMovement;

        Vector3 forward = camTransform.rotation * Vector3.forward;
        Vector3 horizontal = camTransform.rotation * Vector3.right;


        totalMovement = (horizontal * onFootInput.movement.x + forward * onFootInput.movement.y) * moveSpeed * Time.deltaTime;
        totalMovement.y = 0;

        // Если пользователь не жмёт WASD, то вращать не нужно.
        if (totalMovement == Vector3.zero) return;

        Quaternion curRot = transform.rotation;
        Quaternion targetRot = Quaternion.LookRotation(totalMovement);

        transform.rotation = Quaternion.Slerp(curRot, targetRot, rotationSpeed * Time.deltaTime);
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

    void ApplyGravity()
    {
        Vector3 movement = new Vector3();
        isGrounded = characterController.isGrounded;
        if (isGrounded)
        {
            movement.y = -0.5f;
        }
        else
        {
            // Используем отрицательное значение гравитации
            movement.y -= gravity * Time.deltaTime;
            movement.y = Mathf.Max(movement.y, -gravity * 2f);  // Ограничим максимальную скорость падения.
        }
        characterController.Move(movement);
    }
}
