using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTurret : Turret
{
    
    public override void Fire()
    {
        if (greenTurretBulletPrefab != null)
        {
            Vector2 direction = new Vector2(turretBarrelPoint.position.x, turretBarrelPoint.position.y);

            GameObject bullet = Instantiate(greenTurretBulletPrefab, direction, Quaternion.identity);

            Bullet bulletInstance = bullet.GetComponent<Bullet>();

            bulletInstance.SetBulletDirection(turretBarrelPoint.up);
        }
    }

}
