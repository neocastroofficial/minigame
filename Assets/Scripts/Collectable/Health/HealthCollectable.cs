using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthCollectable : Collectable
{
    private void Awake()
    {
        base.minValue = 2;
        base.maxValue = 5;
    }

    public override void ImproveEnemy(IImprovable enemy)
    {
        enemy.GainMaxHealth(base.value);
    }

    
}
