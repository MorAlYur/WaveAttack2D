using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Text TLevel;

    //public delegate void IIttDel(Item item);
    //public static event IIttDel NoviiEvent;
    public enum Mesto {golova,amulet,kolco,grudi,nogi,botinki };
    public enum Kacestvo { normal, uncommon, unusual,epic, legendary}
  
    public bool isActiv;
    public int cislo;

    public string itemName;
    public Kacestvo kacestvo;
   
    public int id;
    public int partID;
    public Mesto mesto;

    public int level;
    public int maxLevel;

    [Header("��� ���������")]
    public float damage;
    public float heals;
    public float armor;
    public float miss;
    public float critChance;
    public float critDamage;
    public float attackSpeed;
    public float shild;


    [Header("����")]
    public float damagePesStart;
    public float damagePerLevel;
    [Header("�����")]
    public float healsPerStart;
    public float healsPerLevel;
    [Header("������")]
    public float armorPerStart;
    public float armorPerLevel;
    [Header("���� ����������")]
    public float missPerStart;
    public float missPerLevel;
    [Header("���� �����")]
    public float critChancePerStart;
    public float critChancePerLevel;
    [Header("���� �����")]
    public float critDamagePerStart;
    public float critDamagePerLevel;
    [Header("�������� �����")]
    public float attackSpeedPerStart;
    public float attackSpeedPerLevel;
    [Header("�������� ������������")]
    public float movementSpeedPerStart;
    public float movementSpeedPerLevel;

    private void Start()
    {
        TLevel = gameObject.GetComponentInChildren<Text>();
        UpdateTextLevel();
        SetParametr();
    }
    public void UpdateTextLevel()
    {
        TLevel.text = level.ToString();

    }
    public void Click()
    {
        //NoviiEvent?.Invoke(this);
    }

    public void SetParametr()
    {
        damage = damagePesStart + damagePerLevel * (level - 1);
        heals = healsPerStart + healsPerLevel * (level - 1);
        armor = armorPerStart + armorPerLevel * (level - 1);
        miss = missPerStart + missPerLevel * (level - 1);
        critChance = critChancePerStart + critChancePerLevel * (level - 1);
        critDamage = critDamagePerStart + critDamagePerLevel * (level - 1);
        attackSpeed = attackSpeedPerStart + attackSpeedPerLevel * (level - 1);
        shild = movementSpeedPerStart + movementSpeedPerLevel * (level - 1);
    }
   
    public string GetItemName()
    {
        return LocalizationManager.Localize(itemName);
    }

}
