using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTurretBullet : Bullet
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        base.moveSpeed = 1f;
        base.minDamage = 3;
        base.maxDamage = 6;
    }

    private void FixedUpdate()
    {
        if(bulletDirection != null)
        {
            BulletMovement(bulletDirection);
        }
    }

    public override void BulletMovement(Vector2 bulletDirection)
    {
        rb.AddForce(bulletDirection * moveSpeed, ForceMode2D.Impulse);
    }

    public override void SetBulletDirection(Vector2 bulletDirection)
    {
        this.bulletDirection = bulletDirection;
    }

    public override void OnBulletPenetrationToEnemy(Health enemyHealth)
    {
        enemyHealth.TakeDamage(base.damage);
        Destroy(gameObject);
    }

    public override void OnBulletPenetrationToEnviorement()
    {

    }
}
