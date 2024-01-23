using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] BaseHealth baseHealth;
    [SerializeField] Slider baseHealthBar;

    void Awake()
    {
        baseHealthBar.maxValue = baseHealth.maxHealth;
        baseHealthBar.value = baseHealthBar.maxValue;
    }

    private void OnEnable()
    {
        baseHealth.OnBaseTakeDamage += DecreaseBaseHealthBarValue;
    }

    private void OnDestroy()
    {
        baseHealth.OnBaseTakeDamage -= DecreaseBaseHealthBarValue;
    }

    private void DecreaseBaseHealthBarValue(int damage)
    {
        baseHealthBar.value -= damage;
        //spesific codes for "healthbar-value decrease process"
    }

}
