using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int maxHealth;

    [SerializeField] private int currentHealth;
    
    public int CurrentHealth => currentHealth;

    public Action<int> healthChanged;

    private void Start()
    {
        currentHealth = maxHealth;
        healthChanged?.Invoke(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthChanged?.Invoke(currentHealth);
    }
}
