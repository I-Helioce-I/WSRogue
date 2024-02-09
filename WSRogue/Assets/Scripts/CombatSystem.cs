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
        if (context.performed)
        {

            switch (currentCombo)
            {
                case ComboState.First:
                    animator.SetTrigger("IsAttacking");
                    break;
                case ComboState.Second:
                    break;
                case ComboState.Third:
                    break;
                default:
                    break;
            }
        }

    }
}
