using UnityEngine;
using System.Collections;

public static class PlayerStats
{
    private static int health = 4;
    private static bool hasRed, hasYellow, hasOrange, hasGreen, hasBlue, hasPurple, isSmall, hasPower;
    

    public static int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public static bool HasRed
    {
        get
        {
            return hasRed;
        }

        set
        {
            hasRed = value;
        }
    }

    public static bool HasYellow
    {
        get
        {
            return hasYellow;
        }

        set
        {
            hasYellow = value;
        }
    }

    public static bool HasOrange
    {
        get
        {
            return hasOrange;
        }

        set
        {
            hasOrange = value;
        }
    }

    public static bool HasGreen
    {
        get
        {
            return hasGreen;
        }

        set
        {
            hasGreen = value;
        }
    }

    public static bool HasBlue
    {
        get
        {
            return hasBlue;
        }

        set
        {
            hasBlue = value;
        }
    }

    public static bool HasPurple
    {
        get
        {
            return hasPurple;
        }

        set
        {
            hasPurple = value;
        }
    }

    public static bool IsSmall
    {
        get
        {
            return isSmall;
        }

        set
        {
            isSmall = value;
        }
    }

    public static bool HasPower
    {
        get
        {
            return hasPower;
        }

        set
        {
            hasPower = value;
        }
    }
}