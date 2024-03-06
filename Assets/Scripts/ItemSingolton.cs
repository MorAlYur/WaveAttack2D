using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Zenject;

public class ItemSingolton : MonoBehaviour
{
    
    public Action OnChangeParametrEvent;

    public HeroesTitle _activHero;

    public List<Item> allitems;
    public List<PartInfo> allItemsPart;

    public List<Item> _itemsNormal;
    public List<Item> _itemsUncommom;
    public List<Item> _itemsUnusual;
    public List<Item> _itemsEpic;
    public List<Item> _itemsLegendary;
    [Inject]
    public Saver _saver;
    public SaveLoadParametrLocal _saveLocal;
    public SaveLoadActivHero _saveLocalActivHero;

    [Header("Все параметры героя")]
    public float _heroDamage;
    public float _heroHeals;
    public float _heroArmor;
    public float _heroMiss;
    public float _heroCritChance;
    public float _heroCritDamage;
    public float _heroAttackSpeed;
    public float _heroShild;
    public float _heroHealPerLevel;
    public float _heroBonusGold;


    [Header("Все параметры инвентаря")]
    public float _iDamage;
    public float _iHeals;
    public float _iArmor;
    public float _iMiss;
    public float _iCritChance;
    public float _iCritDamage;
    public float _iAttackSpeed;
    public float _iShild;

    [Header("Все параметры улучшений")]
    public float _upDamage;
    public float _upHeals;
    public float _upArmor;
    public float _upMiss;
    public float _upCritChance;
    public float _upCritDamage;
    public float _upAttackSpeed;
    public float _upShild;
    public float _upHealPerLevel;
    public float _upBonusGold;

    [Header("Все параметры общие")]
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



   

    public void Start()
    {
        _saveLocal = new SaveLoadParametrLocal();
        _saveLocalActivHero = new SaveLoadActivHero();
        LoadGame();
        SortItemIsKacestvo();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(_heroMiss);
        }
    }

    public void SortItemIsKacestvo()
    {
        foreach (var item in allitems)
        {
            switch (item.kacestvo)
            {
                case Item.Kacestvo.normal:
                    _itemsNormal.Add(item);
                    break;
                case Item.Kacestvo.uncommon:
                    _itemsUncommom.Add(item);
                    break;
                case Item.Kacestvo.unusual:
                    _itemsUnusual.Add(item);
                    break;
                case Item.Kacestvo.epic:
                    _itemsEpic.Add(item);
                    break;
                case Item.Kacestvo.legendary:
                    _itemsLegendary.Add(item);
                    break;
                default:
                    break;
            }
        }
    }
    public void SetParametrInventary(float damage,float heals,float armor,float miss,float critChance,float critDamage,float attackSpeed,float shild)
    {
        _iDamage = damage;
        _iHeals = heals;
        _iArmor = armor;
        _iMiss = miss;
        _iCritChance = critChance;
        _iCritDamage = critDamage;
        _iAttackSpeed = attackSpeed;
        _iShild = shild;
        SetAllParametr();
    }
     public void SetParametrHeroes(float damage, float heals, float armor, float miss, float critChanse, float critDamage, float attackSpeed, float shild, float healPerLevel, float bonusGold)
    {
        Debug.Log(miss);
        _heroDamage = damage;
        _heroHeals = heals;
        _heroArmor = armor;
        _heroMiss = miss;
        _heroCritChance = critChanse;
        _heroCritDamage = critDamage;
        _heroAttackSpeed = attackSpeed;
        _heroShild = shild;
        _heroHealPerLevel = healPerLevel;
        _heroBonusGold = bonusGold;
        Debug.Log(_heroMiss);
        SetAllParametr();
    }

    public void SetParametrUpgrade(float damage,float heals,float armor,float miss,float critChanse,float critDamage,float attackSpeed,float shild,float healPerLevel,float bonusGold)
    {
        _upDamage = damage;
        _upHeals = heals;
        _upArmor = armor;
        _upMiss = miss;
        _upCritChance = critChanse;
        _upCritDamage = critDamage;
        _upAttackSpeed = attackSpeed;
        _upShild = shild;
        _upHealPerLevel = healPerLevel;
        _upBonusGold = bonusGold;
        SetAllParametr();
    }
    public void SetAllParametr()
    {
        _allHeals = _heroHeals + _iHeals + _upHeals;
        _allDamage = _heroDamage + _iDamage + _upDamage;
        _allArmor = _heroArmor + _iArmor + _upArmor;
        _allMiss = _heroMiss + _iMiss + _upMiss;
        _allCritChance = _heroCritChance + _iCritChance + _upCritChance;
        _allCritDamage = _heroCritDamage + _iCritDamage + _upCritDamage;
        _allAttackSpeed = _heroAttackSpeed + ((_iAttackSpeed + _upAttackSpeed)/100);
        _allShild = _heroShild + _iShild + _upShild;
        _allHealPerLevel = _heroHealPerLevel + _upHealPerLevel;
        _allBonusGold = _heroBonusGold + _upBonusGold;
        OnChangeParametrEvent?.Invoke();
        SaveGame();
    }

    public void SaveGame()
    {
        _saveLocal._iDamage=_iDamage;
        _saveLocal._iHeals = _iHeals;
        _saveLocal._iArmor = _iArmor;
        _saveLocal._iMiss = _iMiss;
        _saveLocal._iCritChance = _iCritChance;
        _saveLocal._iCritDamage = _iCritDamage;
        _saveLocal._iAttackSpeed = _iAttackSpeed;
        _saveLocal._iShild = _iShild;

        _saveLocal._upDamage = _upDamage;
        _saveLocal._upHeals = _upHeals;
        _saveLocal._upArmor = _upArmor;
        _saveLocal._upMiss = _upMiss;
        _saveLocal._upCritChance = _upCritChance;
        _saveLocal._upCritDamage = _upCritDamage;
        _saveLocal._upAttackSpeed = _upAttackSpeed;
        _saveLocal._upShild = _upShild;
        _saveLocal._upHealPerLevel = _upHealPerLevel;
        _saveLocal._upBonusGold = _upBonusGold;

        _saveLocal._heroDamage = _heroDamage;
        _saveLocal._heroHeals = _heroHeals;
        _saveLocal._heroArmor = _heroArmor;
        _saveLocal._heroMiss = _heroMiss;
        _saveLocal._heroCritChance = _heroCritChance;
        _saveLocal._heroCritDamage = _heroCritDamage;
        _saveLocal._heroAttackSpeed = _heroAttackSpeed;
        _saveLocal._heroShild = _heroShild;
        _saveLocal._heroHealPerLevel = _heroHealPerLevel;
        _saveLocal._heroBonusGold = _heroBonusGold;

        _saveLocal._allDamage = _allDamage;
        _saveLocal._allHeals = _allHeals;
        _saveLocal._allArmor = _allArmor;
        _saveLocal._allMiss = _allMiss;
        _saveLocal._allCritChance = _allCritChance;
        _saveLocal._allCritDamage = _allCritDamage;
        _saveLocal._allAttackSpeed = _allAttackSpeed;
        _saveLocal._allShild = _allShild;
        _saveLocal._allHealPerLevel = _allHealPerLevel;
        _saveLocal._allBonusGold = _allBonusGold;

        _saver.SaveParametrAll(_saveLocal);
        _saveLocalActivHero._activHero = _activHero;
        _saver.SaveDataActivHero(_saveLocalActivHero);
    }

    public void LoadGame()
    {
        _saveLocal = _saver.LoadParametrAll();

        _iDamage = _saveLocal._iDamage;
        _iHeals = _saveLocal._iHeals;
        _iArmor = _saveLocal._iArmor;
        _iMiss = _saveLocal._iMiss;
        _iCritChance = _saveLocal._iCritChance;
        _iCritDamage = _saveLocal._iCritDamage;
        _iAttackSpeed = _saveLocal._iAttackSpeed;
        _iShild = _saveLocal._iShild;

        _upDamage = _saveLocal._upDamage;
        _upHeals = _saveLocal._upHeals;
        _upArmor = _saveLocal._upArmor;
        _upMiss = _saveLocal._upMiss;
        _upCritChance = _saveLocal._upCritChance;
        _upCritDamage = _saveLocal._upCritDamage;
        _upAttackSpeed = _saveLocal._upAttackSpeed;
        _upShild = _saveLocal._upShild;
        _upHealPerLevel = _saveLocal._upHealPerLevel;
        _upBonusGold = _saveLocal._upBonusGold;

        _heroDamage = _saveLocal._heroDamage;
        _heroHeals = _saveLocal._heroHeals;
        _heroArmor = _saveLocal._heroArmor;
        _heroMiss = _saveLocal._heroMiss;
        _heroCritChance = _saveLocal._heroCritChance;
        _heroCritDamage = _saveLocal._heroCritDamage;
        _heroAttackSpeed = _saveLocal._heroAttackSpeed;
        _heroShild = _saveLocal._heroShild;
        _heroHealPerLevel = _saveLocal._heroHealPerLevel;
        _heroBonusGold = _saveLocal._heroBonusGold;

        _allDamage = _saveLocal._allDamage;
        _allHeals = _saveLocal._allHeals;
        _allArmor = _saveLocal._allArmor;
        _allMiss = _saveLocal._allMiss;
        _allCritChance = _saveLocal._allCritChance;
        _allCritDamage = _saveLocal._allCritDamage;
        _allAttackSpeed = _saveLocal._allAttackSpeed;
        _allShild = _saveLocal._allShild;
        _allHealPerLevel = _saveLocal._allHealPerLevel;
        _allBonusGold = _saveLocal._allBonusGold;

        _saveLocalActivHero = _saver.LoadDataActivHero();
        _activHero = _saveLocalActivHero._activHero;
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void OnApplicationFocus(bool focus)
    {

        if (Time.realtimeSinceStartup > 10f)
        {
            SaveGame();
        }
    }

}

public class SaveLoadParametrLocal
{
    public float _iDamage;
    public float _iHeals;
    public float _iArmor;
    public float _iMiss;
    public float _iCritChance;
    public float _iCritDamage;
    public float _iAttackSpeed;
    public float _iShild;

    public float _upDamage;
    public float _upHeals;
    public float _upArmor;
    public float _upMiss;
    public float _upCritChance;
    public float _upCritDamage;
    public float _upAttackSpeed;
    public float _upShild;
    public float _upHealPerLevel;
    public float _upBonusGold;

    public float _heroDamage;
    public float _heroHeals;
    public float _heroArmor;
    public float _heroMiss;
    public float _heroCritChance;
    public float _heroCritDamage;
    public float _heroAttackSpeed;
    public float _heroShild;
    public float _heroHealPerLevel;
    public float _heroBonusGold;


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

public class SaveLoadActivHero
{
    public HeroesTitle _activHero;
}
