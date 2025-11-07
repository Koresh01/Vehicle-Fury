using Unity.Netcode;
using UnityEngine;


/// <summary>
/// Управляет переменными аниматора.
/// </summary>
public class PlayerAnimationManager : NetworkBehaviour
{
    [SerializeField] OnFootMap onFootInput;

    Animator animator;
    int movement_HASH;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement_HASH = Animator.StringToHash("movement");
    }


    private void Update()
    {
        if (!IsOwner) return;
        UpdateAnimatorValuesServerRpc(onFootInput.movement.magnitude);
    }


    [ServerRpc]
    public void UpdateAnimatorValuesServerRpc(float movement)
    {
        animator.SetFloat(movement_HASH, movement, 0.1f, Time.deltaTime);    // Значение movement, которое передаётся в animator изменяется только на севрере, а клиентУ оно передаётся, потому что мы на игрока повесили NetworkAnimator
    }
}
