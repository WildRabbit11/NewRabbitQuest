using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Moves { None, Fireball }

public enum UniqueEffects { None, GroupManaRestore}

public enum StatusEffects { None, Petrified}

public class MovesAndEffects
{
    //name, damage, manacost, status effect, %chance of applying status effect
    public static (string, int, int, StatusEffects, int) MoveList(Moves moveName)
    {
        switch (moveName)
        {
            case Moves.None:
                return ("N/A", 0, 0, StatusEffects.None, 0);
            case Moves.Fireball:
                return ("Fireball", 15, 15, StatusEffects.None, 0);
            default:
                return("N/A", 0, 0, StatusEffects.None, 0);
        }
    }
}
