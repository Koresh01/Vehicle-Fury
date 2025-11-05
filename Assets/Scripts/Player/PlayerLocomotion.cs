using UnityEngine;

/// <summary>
/// Скрипт по перемещению персонажа.
/// </summary>
public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField] OnFootMap onFootInput;
    CharacterController characterController;
    [SerializeField] Transform camTransform;


    float moveSpeed = 4f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ApplyMovement();
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
}
