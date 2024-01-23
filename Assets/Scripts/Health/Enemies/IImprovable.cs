using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IImprovable
{
    public void GainMaxHealth(int value);
    public void GainDamage(int value);
    public void GainMoveSpeed(int value);
}
