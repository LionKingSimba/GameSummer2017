using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : BaseItemStats
{

    public enum WeaponTypes
    {
        SWORD,
        AXE,
        HAMMER,
        MACE,
        SPEAR,
        // CLUB,
        DAGGER,
        SCYTHE,
        GAUNTLETS,
        CLAWS,
        WARGLAIVES,
        // FAN,
        // WHIP,
        STAFF,
        WAND,
        ORB,
        BOOK,
        RUNE
        // CANE
        // GEM
        // ARTIFACT
    }

    private WeaponTypes weapontype;

    public WeaponTypes WeaponType
    {
        get { return weapontype; }
        set { weapontype = value; }
    }

}
