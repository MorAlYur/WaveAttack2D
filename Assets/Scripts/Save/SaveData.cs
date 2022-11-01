using UnityEngine;
using System;
using System.Collections.Generic;


[Serializable]
public class SaveData
{
    public BankSave _bank = new BankSave();

    public List<ItemSaved> _inventarySaved;
    public bool _newItemInInventary;

    public List<PartSaved> _partSaved;

    public UpgradePersSave _upgradePersSave = new UpgradePersSave();

    public SaveParametrAll _saveParametrAll = new SaveParametrAll();

    public long _allTimeinGame;
    public long _menuTimeinGame;
    public long _gamplayTimeinGame;


    // данные по умолчанию
    public SaveData()
    {
        _inventarySaved = new List<ItemSaved>();
        _newItemInInventary = false;

        _partSaved = new List<PartSaved>();

    }
}

[Serializable]
public class ItemSaved
{
    public int id;
    public int level;
    public int cislo;
    public bool isActive;
}

[Serializable]
public class PartSaved
{
    public int id;
    public int count;
}
[Serializable]
public class UpgradePersSave
{
    public int UpDamageLevelSave;
    public int UpHealsLevelSave;
    public int UpArmorLevelSave;
    public int UpMissLevelSave;
    public int UpCritChanceLevelSave;
    public int UpCritDamageLevelSave;
    public int UpAttackSpeedLevelSave;
    public int UpShildLevelSave;
    public int UpHealPerLevelLevelSave;
    public int UpGoldBonusLevelSave;

    public int allPointUpgrade;
}

[Serializable]
public class BankSave
{
    public int golld;
    public int diamond;
    public int goldInLevell;
    public int diamondInLevel;
    public int allGold;
    public int allDiamond;
}

[Serializable]
public class SaveParametrAll
{
    public float _iDamage;
    public float _iHeals;
    public float _iArmor;
    public float _iMiss;
    public float _iCritChance;
    public float _iCritDamage;
    public float _iAttackSpeed;
    public float _iMovementSpeed;

    public float _upDamage;
    public float _upHeals;
    public float _upArmor;
    public float _upMiss;
    public float _upCritChance;
    public float _upCritDamage;
    public float _upAttackSpeed;
    public float _upMovementSpeed;
    public float _upHealPerLevel;
    public float _upBonusGold;

    public float _allDamage;
    public float _allHeals;
    public float _allArmor;
    public float _allMiss;
    public float _allCritChance;
    public float _allCritDamage;
    public float _allAttackSpeed;
    public float _allShild;
    public float _allHealPerLevel;
    public float _allBonusGold;
}

