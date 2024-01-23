using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IImprovable
{
    [SerializeField] protected Transform enemySpawnPoint;
    [SerializeField] protected Transform[] moveSpots;
    protected int pathIndex;

    public Health enemyHealth {  get; protected set; }

    public float moveSpeed { get; protected set; }

    public int minDamage { get; protected set; }
    public int maxDamage { get; protected set; }

    public int damage { get; protected set; }

    public abstract void Move();
    public abstract void Attack(Health playerOrBaseHealth);

    public void GainDamage(int value)
    {
        minDamage += value;
        maxDamage += value;
    }

    public void GainMoveSpeed(int value)
    {
        moveSpeed += value;
    }

    public void GainMaxHealth(int value)
    {
        enemyHealth.maxHealth += value;
        enemyHealth.currentHealth += value;
    }
}
