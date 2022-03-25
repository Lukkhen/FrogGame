using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Entity entity;

    [Header("Game Manager")]
    public GameManager manager;
    
    [Header("PlayerUI")]
    public Slider health;
    public Slider stamina;

    void Start()
    {
        if (manager == null)
        {
            Debug.LogError("Anexar o Game Manager no player");
            return;
        }

        entity.maxHealth = manager.CalculateHealth(this); 
        entity.maxStamina = manager.CalculateStamina(this);
        int dmg = manager.CalculateDamage(this, 10);

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
