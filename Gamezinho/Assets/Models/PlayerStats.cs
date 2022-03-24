using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Entity entity;
    [Header("PlayerUI")]
    public Slider health;
    public Slider stamina;

    void Start()
    {
        entity.currentHealth = entity.maxHealth;
        entity.currentStamina = entity.maxStamina;
            
        health.maxValue = entity.maxHealth;
        health.value = health.maxValue;

        stamina.maxValue = entity.maxStamina;
        stamina.value = stamina.maxValue;
    }
    private void Update()
    {
        health.value = entity.currentHealth;
        stamina.value = entity.currentStamina;

    }
}
