using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyHealth : Health
{
    public event System.Action<int> OnEnemyTakeDamage;
    public event System.Action OnEnemyDie;

    private void Awake()
    {
        base.maxHealth = 20;
        base.currentHealth = maxHealth;
    }

    public override void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentHealth -= damage;

        Debug.Log("Enemy Took: " + damage + " damage. Current Health: " +  currentHealth);

        OnEnemyTakeDamage?.Invoke(damage);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        gameObject.SetActive(false);
        OnEnemyDie?.Invoke();
    }
}
