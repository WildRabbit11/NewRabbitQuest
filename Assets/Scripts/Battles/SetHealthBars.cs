using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHealthBars : MonoBehaviour
{
    public Slider healthbarP1;
    public Slider healthbarP2;
    public Slider healthbarP3;
    public Slider healthbarE1;
    public Slider healthbarE2;
    public Slider healthbarE3;

    public Slider manabarP1;
    public Slider manabarP2;
    public Slider manabarP3;
    public Slider manabarE1;
    public Slider manabarE2;
    public Slider manabarE3;

    public Text healthTextP1;
    public Text healthTextP2;
    public Text healthTextP3;
    public Text healthTextE1;
    public Text healthTextE2;
    public Text healthTextE3;


    public void RefreshBars(int characterNumber, Unit unit)
    {
        if(characterNumber < 4)
        {
            characterNumber += 1;
        }
        switch (characterNumber)
        {
            case 1:
                healthbarP1.maxValue = unit.maxHP;
                healthbarP1.value = unit.currentHP;
                manabarP1.maxValue = unit.maxMana;
                manabarP1.value = unit.currentMana;
                healthTextP1.text = unit.currentHP.ToString();
                return;
            case 2:
                healthbarP2.maxValue = unit.maxHP;
                healthbarP2.value = unit.currentHP;
                manabarP2.maxValue = unit.maxMana;
                manabarP2.value = unit.currentMana;
                healthTextP2.text = unit.currentHP.ToString();
                return;
            case 3:
                healthbarP3.maxValue = unit.maxHP;
                healthbarP3.value = unit.currentHP;
                manabarP3.maxValue = unit.maxMana;
                manabarP3.value = unit.currentMana;
                healthTextP3.text = unit.currentHP.ToString();
                return;
            case 4:
                healthbarE1.maxValue = unit.maxHP;
                healthbarE1.value = unit.currentHP;
                manabarE1.maxValue = unit.maxMana;
                manabarE1.value = unit.currentMana;
                healthTextE1.text = unit.currentHP.ToString();
                return;
            case 5:
                healthbarE2.maxValue = unit.maxHP;
                healthbarE2.value = unit.currentHP;
                manabarE2.maxValue = unit.maxMana;
                manabarE2.value = unit.currentMana;
                healthTextE2.text = unit.currentHP.ToString();
                return;
            case 6:
                healthbarE3.maxValue = unit.maxHP;
                healthbarE3.value = unit.currentHP;
                manabarE3.maxValue = unit.maxMana;
                manabarE3.value = unit.currentMana;
                healthTextE3.text = unit.currentHP.ToString();
                return;
            default:
                return;
        }
    }
}
