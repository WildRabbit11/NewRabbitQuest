using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogAType
{
    //private int currentUnitID;
    //private int speed;
    //private AttackType currentAttackType;
    //private int enemyID;



    public int casterID { get; set; }
    public int casterSpeed { get; set; }
    public AttackType attackType { get; set; }
    public int targetID { get; set; }

    public LogAType(int currentUnitID, int speed, AttackType currentAttackType, int enemyID)
    {
        this.casterID = currentUnitID;
        this.casterSpeed = speed;
        this.attackType = currentAttackType;
        this.targetID = enemyID;
    }

    //public int CompareTo(LogAType logAType)
    //{
    //    return this.casterSpeed.CompareTo(logAType.casterSpeed);
    //}

}

public class SortByCasterSpeed : IComparer<LogAType>
{
    public int Compare(LogAType a, LogAType b)
    {
        return b.casterSpeed.CompareTo(a.casterSpeed);
    }
}
