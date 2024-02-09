using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ComboState
{
    First,
    Second,
    Third
}
public class CombatSystem : MonoBehaviour
{
    PlayerController pC;
    Animator animator;

    [SerializeField] ComboState currentCombo;



    private void Start()
    {
        pC = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed )
        {

            switch (currentCombo)
            {
                case ComboState.First:
                    animator.SetInteger("CurrentCombo", 1);
                    animator.SetTrigger("IsAttacking");
                    currentCombo = ComboState.Second;
                    
                    break;
                case ComboState.Second:
                    animator.SetInteger("CurrentCombo", 2);
                    animator.SetTrigger("IsAttacking");
                    currentCombo = ComboState.Third;
                    break;
                case ComboState.Third:
                    animator.SetInteger("CurrentCombo", 3);
                    animator.SetTrigger("IsAttacking");
                    currentCombo = ComboState.First;
                    break;
                default:
                    break;
            }
        }
    }
}
