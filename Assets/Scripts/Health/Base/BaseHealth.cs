using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : Health
{
    public event System.Action<int> OnBaseTakeDamage;
    public event System.Action OnBaseDie;

    private void Awake()
    {
        base.maxHealth = 300;
        base.currentHealth = maxHealth;
    }

    public override void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentHealth -= damage;
        Debug.Log("Base took " + damage + " damage. Current health: " +  currentHealth);

        OnBaseTakeDamage?.Invoke(damage);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
        OnBaseDie?.Invoke();
    }
}
