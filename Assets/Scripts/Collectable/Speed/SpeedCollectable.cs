using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCollectable : Collectable
{
    private void Awake()
    {
        base.minValue = 1;
        base.maxValue = 3;
    }

    public override void ImproveEnemy(IImprovable enemy)
    {
        enemy.GainMoveSpeed(base.value);
    }
}
