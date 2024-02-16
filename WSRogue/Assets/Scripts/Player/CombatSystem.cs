using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    [SerializeField] private Collider attackCollider;

    [SerializeField] ComboState currentCombo;

    [Header("Stats")]
    [SerializeField] public float damage;
    [SerializeField] List<EnemyController> enemyControllers;

    public enum WeaponState
    {
        OneHand,
        SecondHand
    }

    [SerializeField] WeaponState weaponState;


    private void Start()
    {
        pC = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
        enemyControllers = new List<EnemyController>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
                    Attack();

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

    private void Attack()
    {
        foreach (EnemyController enemy in enemyControllers)
        {
            Debug.Log("Attack");
            enemy.TakeDamage(damage);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyController>(out EnemyController enemyController))
        {
            enemyControllers.Add(enemyController);

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<EnemyController>(out EnemyController enemyController))
        {
            enemyControllers.Remove(enemyController);

        }
    }
}