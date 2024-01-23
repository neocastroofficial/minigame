using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollectable : Collectable
{
    private void Awake()
    {
        base.minValue = 5;
        base.maxValue = 9;
    }

    public override void ImproveEnemy(IImprovable enemy)
    {
        enemy.GainDamage(base.value);
    }
}
