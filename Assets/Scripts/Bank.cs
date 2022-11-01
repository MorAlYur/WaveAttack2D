using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public  class Bank : MonoBehaviour
{

    public int gold { get; private set; }
    public int diamond { get; private set; }

    public  int goldInLevel { get; private set; }
    public  int diamodInLevel { get; private set; }

    public  int allGold { get; private set; }
    public  int allDiamond { get; private set; }

    

    public delegate void BankDelegateGold(int oldGoldValue, int newGoldValue);
    public  event BankDelegateGold bankGoldEvent;
    public delegate void BankDelegateDiamond(int oldDiamodValue, int newDiamodValue);
    public  event BankDelegateDiamond bankDiamodEvent;

    public delegate void SetGoldAndDiamindOldDelegate(int goldOld,int DiamondOld);
    public event SetGoldAndDiamindOldDelegate SetGoldAndDiamindOldEvent;
   
    public SaveLoadBank _saveBankLocal;
    [Inject]
    public Saver _saver;


    //private void Awake()
    //{
    //    if (_saveBankLocal != null)
    //    {
    //        _saveBankLocal = new SaveLoadBank();
    //    }
    //}
    private void OnEnable()
    {
        LoadBank();       
    } 
    public void SetInitialValues()
    {
        SetGoldAndDiamindOldEvent?.Invoke(gold, diamond);
    }
    public  void AddGold(int goldd)
    {
        var old = gold;
        gold += goldd;
        allGold += goldd;
        SaveBank();
        bankGoldEvent?.Invoke(old, gold);
    }

    public  void SpendGold(int goldd)
    {
        var old = gold;
        gold -= goldd;
        SaveBank();
        bankGoldEvent?.Invoke(old, gold);
    }

    public  bool IsEnaughtGold(int goldd)
    {
        return gold >= goldd;
    }
    public  void AddDiamond(int diamondd)
    {
        var old = diamond;
        diamond += diamondd;
        allDiamond += diamondd;
        SaveBank();
        bankDiamodEvent?.Invoke(old, diamond);
    }

    public  void SpendDiamond(int diamondd)
    {
        var old = diamond;
        diamond -= diamondd;
        SaveBank();
        bankDiamodEvent?.Invoke(old, diamond);
    }
   
    public  bool IsEnaughtDiamond(int diamondd)
    {
        return diamond >= diamondd;
    }

    public  void AddGoldInLevel(int goldd)
    {
        goldInLevel += goldd;
        SaveBank();
    }
    public  void AddDiamondInLevel(int diamondd)
    {
        diamodInLevel += diamondd;
        SaveBank();
    }

    public  void AddGoldAndDiamondInLevel()
    {
        if (goldInLevel != 0)
        {
            AddGold(goldInLevel);
            goldInLevel = 0;
        }
        if (diamodInLevel != 0)
        {
            AddDiamond(diamodInLevel);
            diamodInLevel = 0;
        }
        SaveBank();
    }
    public  void SaveBank()
    {
        _saveBankLocal.golld = gold;
        _saveBankLocal.diamond = diamond;
        _saveBankLocal.goldInLevell = goldInLevel;
        _saveBankLocal.diamondInLevel = diamodInLevel;
        _saveBankLocal.allDiamond = allDiamond;
        _saveBankLocal.allGold = allGold;
        _saver.SaveDataBank(_saveBankLocal);

    }
    public void LoadBank()
    {
        
        _saveBankLocal = _saver.LoadDataBank();
        gold = _saveBankLocal.golld;
        diamond = _saveBankLocal.diamond;
        goldInLevel = _saveBankLocal.goldInLevell;
        diamodInLevel = _saveBankLocal.diamondInLevel;
        allGold = _saveBankLocal.allGold;
        allDiamond = _saveBankLocal.allDiamond;       
    }


}
public class SaveLoadBank
{
    public int golld;
    public int diamond;
    public int goldInLevell;
    public int diamondInLevel;
    public int allGold;
    public int allDiamond;
}
