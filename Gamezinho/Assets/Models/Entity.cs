using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Entity
{
    [Header("Name")]
    public string name;

    [Header("Health")]
    public int currentHealth;
    public int maxHealth;

    [Header("Stamina")]
    public int currentStamina;
    public int maxStamina;

    [Header("Stats")]
    //public int defense = 1;
    public float speed = 2f;




}