using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum uniqueEffect { None, ManaRestore }

//public enum statusEffect { None, Petrified }

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int phyDamage;
    public int magDamage;

    public int phyDefence;
    public int magDefence;
    
    public int maxHP;
    public int currentHP;

    public int maxMana;
    public int currentMana;

    public int speed;

    public Moves move1;
    public Moves move2;
    public Moves move3;

    public UniqueEffects uniqueEffect;
    public StatusEffects statusEffect;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;//true if unit has died
        else
            return false;//false if unit is still alive
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }
}
