using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class TakeDamageAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");

    private void OnEnable()
    {
        GetComponent<Health>().onDamaged?.AddListener(PlayDamageAnimation);
    }

    private void OnDisable()
    {
        GetComponent<Health>().onDamaged?.RemoveListener(PlayDamageAnimation);
    }

    private void PlayDamageAnimation(int damage)
    {
        animator.SetTrigger(TakeDamage);
    }
}
