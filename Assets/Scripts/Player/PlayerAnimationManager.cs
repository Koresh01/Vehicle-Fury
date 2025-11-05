using UnityEngine;


/// <summary>
/// Управляет переменными аниматора.
/// </summary>
public class PlayerAnimationManager : MonoBehaviour
{
    Animator animator;
    int movement_HASH;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement_HASH = Animator.StringToHash("movement");
    }


    public void UpdateAnimatorValues(float movement)
    {
        animator.SetFloat(movement_HASH, movement);
    }
}
