using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyController : Enemy
{   
    private bool canMove, canAttack;

    void Awake()
    {
        base.enemyHealth = GetComponent<Health>();
        base.minDamage = 5;
        base.maxDamage = 10;
        base.moveSpeed = 1f;
        
        canMove = true;
        canAttack = true;
        pathIndex = 0;
    }

    void FixedUpdate()
    {
        float targetDistanceThreshold = 0.1f;

        float targetDistance = Vector2.Distance(moveSpots[pathIndex].position, transform.position);

        if (canMove)
        {
            if (targetDistance < targetDistanceThreshold && pathIndex < moveSpots.Length - 1)
            {
                pathIndex++;
            }

            Move();
        }

    }

    public override void Move ()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[pathIndex].transform.position, moveSpeed * Time.deltaTime);
    }

    public override void Attack(Health playerOrBaseHealth)
    {
        base.damage = Random.Range(minDamage, maxDamage);

        playerOrBaseHealth.TakeDamage(damage);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Base") && canAttack)
        {
            Health playerOrBaseHealth = collision.gameObject.GetComponent<Health>();
            Attack(playerOrBaseHealth);

            // killes itself after collided
            enemyHealth.Die();
        }
    }

}
