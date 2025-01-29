using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    //Fields
    int CurrentHealth;
    int CurrentMaxHealth;

    //Properties
    public int Health
    {
        get
        { 
            return CurrentHealth; 
        }
        set
        {
            CurrentHealth = value;
        }
    }
    public int MaxHealth
    {
        get 
        { 
        return CurrentMaxHealth;
        }
        set 
        { 
          CurrentMaxHealth = value;
        }
    }
    // Constructor
    public HealthSystem(int health, int maxHealth)
    {
        CurrentHealth = health;
        CurrentMaxHealth = maxHealth;
    }

    //Methods
    public void DmgUnit(int DmgAmount)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth += DmgAmount;

        }
    }
    public void HealUnit(int healAmount)
    {
        if (CurrentHealth < CurrentMaxHealth) 
        { 
            CurrentHealth -= healAmount;
        }
        if(CurrentHealth > CurrentMaxHealth) 
        { 
            CurrentHealth = CurrentMaxHealth;
        }
    }
}
