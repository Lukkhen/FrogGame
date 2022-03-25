using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Int32 CalculateHealth(PlayerStats player)
    {
        Int32 result = 30;
        Debug.LogFormat("CalculateHealth: {0}", result);
        return result;
    }
    public Int32 CalculateStamina(PlayerStats player)
    {
        Int32 result = 20;
        Debug.LogFormat("CalculateStamina: {0}", result);
        return result;
    }
    public Int32 CalculateDamage(PlayerStats player, int weaponDamage)
    {
        System.Random rnd = new System.Random();
        Int32 result = (weaponDamage * 2) + rnd.Next(1, 20);
        Debug.LogFormat("CalculateDamage: {0}", result);
        return result;
    }
}