using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class SuitUpgrades : MonoBehaviour
{
    public enum upgrades { Base, Fire, Radiation, Stealth };
    public upgrades currentSuit;
    public upgrades previousSuit;
    public upgrades nextSuit;

    public const int MAX_SUITS = 4;
    public bool[] UnlockedSuit = new bool[MAX_SUITS];

    public static explicit operator SuitUpgrades(int v)
    {
        throw new NotImplementedException();
    }
}

