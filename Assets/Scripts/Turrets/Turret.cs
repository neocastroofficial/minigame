using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    [SerializeField] protected GameObject greenTurretBulletPrefab;
    [SerializeField] protected Transform turretBarrelPoint;
    [SerializeField] protected float fireRate;

    private Vector2 targetPos;

    public bool canFire { get; protected set; }

    public float waitForReload { get; protected set; }


    private void Awake()
    {
        targetPos = transform.position;
    }


    void FixedUpdate()
    {
        if (targetPos != null && canFire)
        {
            TurnTheBarrelToTheEnemy(targetPos);

            waitForReload += Time.fixedDeltaTime;

            if (waitForReload >= 1f / fireRate)
            {
                Fire();
                waitForReload = 0.0f;
            }
        }
    }

    public abstract void Fire();

    private void TurnTheBarrelToTheEnemy(Vector2 enemyPos)
    {
        Vector2 target = new Vector2(enemyPos.x - transform.position.x, enemyPos.y - transform.position.y);
        transform.up = target;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            targetPos = collision.transform.position;
            canFire = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            canFire = false;

        }
    }

}
