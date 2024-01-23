using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] LayerMask targetLayerMask;

    public float moveSpeed {  get; protected set; }
    public int minDamage {  get; protected set; }
    public int maxDamage { get; protected set;}
    public int damage { get; protected set; }
    public Vector2 bulletDirection { get; protected set; }

    private void Update()
    {
        damage = Random.Range(minDamage, maxDamage);
        BulletOffScreenHandler();
        BulletRaycastHandler();
    }

    private void BulletOffScreenHandler()
    {
        Vector2 bulletPos = Camera.main.WorldToScreenPoint(transform.position);

        if (bulletPos.x < 0 || bulletPos.x > Camera.main.scaledPixelWidth
                            || bulletPos.y < 0 
                            || bulletPos.y > Camera.main.scaledPixelHeight)
        {
            Destroy(gameObject);
        }
    }

    private void BulletRaycastHandler()
    {
        float raycastDistance = .07f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, raycastDistance, targetLayerMask);

        if(hit.collider != null)
        {
            if(hit.collider.CompareTag("Enemy"))
            {
                Health enemyHealth = hit.collider.GetComponent<Health>();
                OnBulletPenetrationToEnemy(enemyHealth);

            } else
            {
                OnBulletPenetrationToEnviorement();
            }
        }
    }

    public abstract void BulletMovement(Vector2 direction);

    public abstract void OnBulletPenetrationToEnemy(Health enemyHealth);

    public abstract void OnBulletPenetrationToEnviorement();

    public abstract void SetBulletDirection(Vector2 bulletDirection);
}
