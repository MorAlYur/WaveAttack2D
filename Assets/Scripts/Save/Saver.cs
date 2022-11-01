using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saver : MonoBehaviour
{

    private SaveJSON _saveJSON;
    public SaveData _saveData;

    private void Awake()
    {
        _saveJSON = new SaveJSON();
        LoadGame();
    }


    public void LoadGame()
    {
        _saveData = _saveJSON.Load();
    }
    public void SaveGame()
    {
        _saveJSON.Save(_saveData);
    }
    #region // банк
    public void SaveDataBank(SaveLoadBank bank)
    {
        _saveData._bank.diamond = bank.diamond;
        _saveData._bank.diamondInLevel = bank.diamondInLevel;
        _saveData._bank.golld = bank.golld;
        _saveData._bank.goldInLevell = bank.goldInLevell;
        _saveData._bank.allGold = bank.allGold;
        _saveData._bank.allDiamond = bank.allDiamond;
    }
    public SaveLoadBank LoadDataBank()
    {
        SaveLoadBank save = new SaveLoadBank();
        save.diamond = _saveData._bank.diamond;
        save.diamondInLevel = _saveData._bank.diamondInLevel;
        save.golld = _saveData._bank.golld;
        save.goldInLevell = _saveData._bank.goldInLevell;
        save.allDiamond = _saveData._bank.allDiamond;
        save.allGold = _saveData._bank.allGold;
        return save;
    }
    #endregion
    #region //для инвентаря
    #region // для айтемов
    public void SaveDataInventaryAll(List<Item> items)
    {
        _saveData._inventarySaved.Clear();
        foreach (var item in items)
        {
            var newItemSave = new ItemSaved();
            newItemSave.cislo = item.cislo;
            newItemSave.id = item.id;
            newItemSave.level = item.level;
            newItemSave.isActive = item.isActiv;
            _saveData._inventarySaved.Add(newItemSave);
        }
    }
    public void AddItemToInventarySaveData(Item item)
    {
        var newItemSave = new ItemSaved();
        newItemSave.cislo = item.cislo;
        newItemSave.id = item.id;
        newItemSave.level = item.level;
        newItemSave.isActive = item.isActiv;
        _saveData._inventarySaved.Add(newItemSave);
        _saveData._newItemInInventary = true;
    }
   public List<ItemSaved> LoadDataInventary()
    {
        return _saveData._inventarySaved;
    }
    public bool GetNewItemInInventary()
    {
        return _saveData._newItemInInventary;
    }
    public void SetNewItemInInventary(bool isNewItemInInventary)
    {
        _saveData._newItemInInventary = isNewItemInInventary;
    }
    #endregion

    #region // для частей айтемов
    public void SavaDataPartAll(List<PartInfo> parts)
    {
        _saveData._partSaved.Clear();
        foreach (var part in parts)
        {
            var newPartSave = new PartSaved();
            newPartSave.id = part.ID;
            newPartSave.count = part.Count;
            _saveData._partSaved.Add(newPartSave);
        }
    }
    public void AddToPartSaveData(int id,int count)
    {
        foreach (var part in _saveData._partSaved)
        {
            if(part.id == id)
            {
                part.count += count;
            }
        }
    }
    public List<PartSaved> LoadDataPart()
    {
        return _saveData._partSaved;
    }
    #endregion
    #endregion
    #region // улучшение персонажа общие
    public void SaveDataUpgradePers(SaveLoadUpgradeMenu saveLoadUpgradeMenu)
    {
        _saveData._upgradePersSave.UpDamageLevelSave = saveLoadUpgradeMenu.UpDamageLevelSave; 
        _saveData._upgradePersSave.UpHealsLevelSave = saveLoadUpgradeMenu.UpHealsLevelSave; 
        _saveData._upgradePersSave.UpArmorLevelSave = saveLoadUpgradeMenu.UpArmorLevelSave; 
        _saveData._upgradePersSave.UpMissLevelSave = saveLoadUpgradeMenu.UpMissLevelSave; 
        _saveData._upgradePersSave.UpCritChanceLevelSave = saveLoadUpgradeMenu.UpCritChanceLevelSave; 
        _saveData._upgradePersSave.UpCritDamageLevelSave = saveLoadUpgradeMenu.UpCritDamageLevelSave; 
        _saveData._upgradePersSave.UpAttackSpeedLevelSave = saveLoadUpgradeMenu.UpAttackSpeedLevelSave; 
        _saveData._upgradePersSave.UpShildLevelSave = saveLoadUpgradeMenu.UpShildLevelSave; 
        _saveData._upgradePersSave.UpHealPerLevelLevelSave = saveLoadUpgradeMenu.UpHealPerLevelLevelSave; 
        _saveData._upgradePersSave.UpGoldBonusLevelSave = saveLoadUpgradeMenu.UpGoldBonusLevelSave; 

        _saveData._upgradePersSave.allPointUpgrade = saveLoadUpgradeMenu.allPointUpgrade;
    }
    public SaveLoadUpgradeMenu LoadDataUpgradePers()
    {
        SaveLoadUpgradeMenu saved = new SaveLoadUpgradeMenu();
        saved.UpDamageLevelSave = _saveData._upgradePersSave.UpDamageLevelSave;
        saved.UpHealsLevelSave = _saveData._upgradePersSave.UpHealsLevelSave;
        saved.UpArmorLevelSave = _saveData._upgradePersSave.UpArmorLevelSave;
        saved.UpMissLevelSave = _saveData._upgradePersSave.UpMissLevelSave;
        saved.UpCritChanceLevelSave = _saveData._upgradePersSave.UpCritChanceLevelSave;
        saved.UpCritDamageLevelSave = _saveData._upgradePersSave.UpCritDamageLevelSave;
        saved.UpAttackSpeedLevelSave = _saveData._upgradePersSave.UpAttackSpeedLevelSave;
        saved.UpShildLevelSave = _saveData._upgradePersSave.UpShildLevelSave;
        saved.UpHealPerLevelLevelSave = _saveData._upgradePersSave.UpHealPerLevelLevelSave;
        saved.UpGoldBonusLevelSave = _saveData._upgradePersSave.UpGoldBonusLevelSave;

        saved.allPointUpgrade = _saveData._upgradePersSave.allPointUpgrade;
        return saved;
    }
    #endregion

    #region //для подменю улучшения
    public void SaveParametrAll(SaveLoadParametrLocal saveLoadParametrLocal)
    {
        _saveData._saveParametrAll._iDamage = saveLoadParametrLocal._iDamage;
        _saveData._saveParametrAll._iHeals = saveLoadParametrLocal._iHeals;
        _saveData._saveParametrAll._iArmor = saveLoadParametrLocal._iArmor;
        _saveData._saveParametrAll._iMiss = saveLoadParametrLocal._iMiss;
        _saveData._saveParametrAll._iCritChance = saveLoadParametrLocal._iCritChance;
        _saveData._saveParametrAll._iCritDamage = saveLoadParametrLocal._iCritDamage;
        _saveData._saveParametrAll._iAttackSpeed = saveLoadParametrLocal._iAttackSpeed;
        _saveData._saveParametrAll._iMovementSpeed = saveLoadParametrLocal._iShild;

        _saveData._saveParametrAll._upDamage = saveLoadParametrLocal._upDamage;
        _saveData._saveParametrAll._upHeals = saveLoadParametrLocal._upHeals;
        _saveData._saveParametrAll._upArmor = saveLoadParametrLocal._upArmor;
        _saveData._saveParametrAll._upMiss = saveLoadParametrLocal._upMiss;
        _saveData._saveParametrAll._upCritChance = saveLoadParametrLocal._upCritChance;
        _saveData._saveParametrAll._upCritDamage = saveLoadParametrLocal._upCritDamage;
        _saveData._saveParametrAll._upAttackSpeed = saveLoadParametrLocal._upAttackSpeed;
        _saveData._saveParametrAll._upMovementSpeed = saveLoadParametrLocal._upShild;
        _saveData._saveParametrAll._upHealPerLevel = saveLoadParametrLocal._upHealPerLevel;
        _saveData._saveParametrAll._upBonusGold = saveLoadParametrLocal._upBonusGold;

        _saveData._saveParametrAll._allDamage = saveLoadParametrLocal._allDamage;
        _saveData._saveParametrAll._allHeals = saveLoadParametrLocal._allHeals;
        _saveData._saveParametrAll._allArmor = saveLoadParametrLocal._allArmor;
        _saveData._saveParametrAll._allMiss = saveLoadParametrLocal._allMiss;
        _saveData._saveParametrAll._allCritChance = saveLoadParametrLocal._allCritChance;
        _saveData._saveParametrAll._allCritDamage = saveLoadParametrLocal._allCritDamage;
        _saveData._saveParametrAll._allAttackSpeed = saveLoadParametrLocal._allAttackSpeed;
        _saveData._saveParametrAll._allShild = saveLoadParametrLocal._allShild;
        _saveData._saveParametrAll._allHealPerLevel = saveLoadParametrLocal._allHealPerLevel;
        _saveData._saveParametrAll._allBonusGold = saveLoadParametrLocal._allBonusGold;

    }
    public SaveLoadParametrLocal LoadParametrAll()
    {
        SaveLoadParametrLocal saved = new SaveLoadParametrLocal();

        saved._iDamage = _saveData._saveParametrAll._iDamage;
        saved._iHeals = _saveData._saveParametrAll._iHeals;
        saved._iArmor = _saveData._saveParametrAll._iArmor;
        saved._iMiss = _saveData._saveParametrAll._iMiss;
        saved._iCritChance = _saveData._saveParametrAll._iCritChance;
        saved._iCritDamage = _saveData._saveParametrAll._iCritDamage;
        saved._iAttackSpeed = _saveData._saveParametrAll._iAttackSpeed;
        saved._iShild = _saveData._saveParametrAll._iMovementSpeed;

        saved._upDamage = _saveData._saveParametrAll._upDamage;
        saved._upHeals = _saveData._saveParametrAll._upHeals;
        saved._upArmor = _saveData._saveParametrAll._upArmor;
        saved._upMiss = _saveData._saveParametrAll._upMiss;
        saved._upCritChance = _saveData._saveParametrAll._upCritChance;
        saved._upCritDamage = _saveData._saveParametrAll._upCritDamage;
        saved._upAttackSpeed = _saveData._saveParametrAll._upAttackSpeed;
        saved._upShild = _saveData._saveParametrAll._upMovementSpeed;
        saved._upHealPerLevel = _saveData._saveParametrAll._upHealPerLevel;
        saved._upBonusGold = _saveData._saveParametrAll._upBonusGold;

        saved._allDamage = _saveData._saveParametrAll._allDamage;
        saved._allHeals = _saveData._saveParametrAll._allHeals;
        saved._allArmor = _saveData._saveParametrAll._allArmor;
        saved._allMiss = _saveData._saveParametrAll._allMiss;
        saved._allCritChance = _saveData._saveParametrAll._allCritChance;
        saved._allCritDamage = _saveData._saveParametrAll._allCritDamage;
        saved._allAttackSpeed = _saveData._saveParametrAll._allAttackSpeed;
        saved._allShild = _saveData._saveParametrAll._allShild;
        saved._allHealPerLevel = _saveData._saveParametrAll._allHealPerLevel;
        saved._allBonusGold = _saveData._saveParametrAll._allBonusGold;

        return saved;
    }
    #endregion
    #region // выход из игры
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void OnApplicationFocus(bool focus)
    {
#if UNITY_EDITOR_64
        return;
#endif
        SaveGame();

    }
    #endregion
}

