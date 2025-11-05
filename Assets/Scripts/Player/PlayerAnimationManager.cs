using UnityEngine;


/// <summary>
/// Управляет переменными аниматора.
/// </summary>
public class PlayerAnimationManager : MonoBehaviour
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
        UpdateAnimatorValues(onFootInput.movement.magnitude);
    }


    public void UpdateAnimatorValues(float movement)
    {
        animator.SetFloat(movement_HASH, movement, 0.1f, Time.deltaTime);
    }
}
