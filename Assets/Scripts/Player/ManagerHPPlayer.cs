using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ManagerHPPlayer : MonoBehaviour
{
    public delegate void ChahgeHP(int change,int newCount,bool isDamage);
    public event ChahgeHP ChangeHPEvent;
    public delegate void ChahgeShild(int change, int newCount, bool isDamage);
    public event ChahgeShild ChangeShildEvent;
    public event Action<int,int,bool> MaxHPEvent;
    public event Action<int,int,bool> MaxShildEvent;
    public event Action MissEvent;
    public event Action<int> TakeDamage1;


    public LevelPlayer _levelPlayer;

    public bool _goodMod;
    public float _timeGoodMod;
    
    public int HP;
    public int shild;

    [Header("Все параметры")]
    public int maxHP;
    public int healsPerLevel;
    public int maxShild;
    public int damage;
    public int armor;
    public float miss;
    public float critChanse;
    public float critDamage;
    public float attackSpped;

    public float maxMiss;
    public float maxCritChanse;
    public float maxAttackSpeed;
    public int maxDopCountBullet;

    public int damageFire;
    public int damageToxic;
    public float _coofFireDamage;
    public float _coofToxicDamage;
    [Header("Шанс дропа")]
    public float _dopExpPR;
    public float _dopGoldPR;
    public float _dopDropDiamondPR;
    public float _dopPrDropPart;
    public float _dopPrHeart;


    //public GameObject prefabPuli;
    [Header("Бонусы")]
    public bool isFire;               //ядовитые пули
    public bool isToxic;              //огненные пули
    public bool skvozniePuli;         // сквозные пули
    public bool jumpPuli;             //прыгающие пули
    public bool rikoshetPuli;         // рикошет
    public bool addNewPuli;           // дополнительная пуля при попадании во врага
    public int countBullet;           // количество пуль в основном выстеле(двухстволка, трехстволка)
    public int dopCountBullet;        // доп. пули под углами(15,30,45,60,75)
    public bool bullet90;             // доп. вертикальные пули
    public bool bullet180;            // доп. пуля назад
    public bool dubleShot;            // доп. выстрел
    public bool isVampiric;           // исцеление при смерти врага
    public int vampiricHelsing;    // количество востанавливающихся жизней
    public bool bangNormal;
    public bool bangFire;
    public bool bangToxic;



    private int _layerPlayer = 8;
    private int[] _layerEnemy = new int[] {13,14,15,16};

    [Inject]
    private ItemSingolton _itemSingolton;

    private void OnEnable()
    {
        _levelPlayer.ActivBonusMenuEvent += NewLevel;
    }

    private void NewLevel()
    {
        SetHP(healsPerLevel, false);
    }

    private void Start()
    {

        SetStartParamertPers();
        SetDamageFireAndToxic();
        SetMaxHP(maxHP,HP,true);
        SetMaxShild(maxShild,shild,true);
        SetDamageFireAndToxic();
    }
    private void SetStartParamertPers()
    {
        maxHP =(int)_itemSingolton._allHeals;
        healsPerLevel =(int)_itemSingolton._allHealPerLevel;
        maxShild = (int)_itemSingolton._allShild;
        damage = (int)_itemSingolton._allDamage;
        armor = (int)_itemSingolton._allArmor;
        miss = _itemSingolton._allMiss;
        critChanse = _itemSingolton._allCritChance;
        critDamage = _itemSingolton._allCritDamage;
        attackSpped = _itemSingolton._allAttackSpeed;
        HP = maxHP;
        shild = maxShild;


    }
    public void SetDamageFireAndToxic()
    {
        damageFire = (int)(damage * _coofFireDamage);
        damageToxic = (int)(damage * _coofToxicDamage);
    }
    public void SetMaxHP(int maxxHP,int HP,bool isSetHP)
    {
        maxHP = maxxHP;
        MaxHPEvent?.Invoke(maxHP,HP, isSetHP);

    }
    public void SetMaxShild(int maxxShild,int shild,bool isSetShild)
    {
        maxShild = maxxShild;
        MaxShildEvent?.Invoke(maxShild,shild, isSetShild);
    }
    public void SetHP(int changeHP,bool isDamage)
    {
        if (isDamage == true)
        {
            HP -= changeHP;
            ChangeHPEvent?.Invoke(changeHP, HP, true);
        }
        else
        {
            if (HP + changeHP <= maxHP)
            {
                HP += changeHP;
                ChangeHPEvent?.Invoke(changeHP, HP, false);
            }
            else
            {
                HP = maxHP;
                ChangeHPEvent?.Invoke(changeHP, HP, false);
            }          
        }
    }
    public void SetShild(int changeShild,bool isDamage)
    {
        if (isDamage == true)
        {
            if (shild == 0)
            {
                SetHP(ArmorPenetration(changeShild), true);
                return;
            }
            if (changeShild >= shild)
            {
                var can = shild;
                shild = 0;
                ChangeShildEvent?.Invoke(can, shild, true);
                int izbChangeShild = changeShild - can;
                SetHP(ArmorPenetration(izbChangeShild), true);
            }
            else
            {
                shild -= changeShild;
                ChangeShildEvent?.Invoke(changeShild,shild, true);
            }
        }
        else
        {
            if (shild + changeShild <= maxShild)
            {
                shild += changeShild;
                ChangeShildEvent?.Invoke(changeShild, shild, false);
            }
            else
            {
                shild = maxShild;
                ChangeShildEvent?.Invoke(changeShild, shild, false);
                
            }
        }

    }
    public int ArmorPenetration(int damage)
    {
        float proctntPonizenija = (100 * (armor * 0.01f) / (2 + armor * 0.01f))*0.01f;
        int d = (int)(damage - (damage * proctntPonizenija));
        return d;
    }
    public  void TakeDamag(int damage)
    {
        if (_goodMod == true)
        {
            return;
        }
        TakeDamage1?.Invoke(damage);
        int r = UnityEngine.Random.Range(0, 10000);
        if (r <= miss * 100)
        {
            MissEvent?.Invoke();
            return;
        }
        StartCoroutine(SetGoodMod());

        SetShild(damage, true);
        
    }
    
    IEnumerator SetGoodMod()
    {
        foreach (var layer in _layerEnemy)
        {
            Physics2D.IgnoreLayerCollision(_layerPlayer, layer, true);
        }
        _goodMod = true;
        yield return new WaitForSeconds(_timeGoodMod);
        _goodMod = false;
        foreach (var layer in _layerEnemy)
        {
            Physics2D.IgnoreLayerCollision(_layerPlayer, layer, false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EmenyHPManager emenyHPManager)) 
            TakeDamag(emenyHPManager.damageMele);
    }

    #region // изменение параметров
    public void ChangeAttackSpeed(float coof)
    {
        attackSpped = attackSpped * coof;
    }
    public void ChangeDamage(float coof)
    {
        damage = (int)(damage * coof);
        SetDamageFireAndToxic();
    }
    public void ChangeDamage(int bonusDamage)
    {
        damage += bonusDamage;
    }

    public void ChangeArmor(float coof)
    {
        armor = (int)(armor * coof);
    }
    public void ChangeArmor(int bonusArmor)
    {
        armor += bonusArmor;
    }
    public void ChangeCritChanse(float bonusCritChanse)   
    {
        critChanse += bonusCritChanse;
        if(critChanse>maxCritChanse)
            critChanse = maxCritChanse;
    }
    public void ChangeCritDamage(int bonusCritDamage)   
    {
        critDamage += bonusCritDamage;
    }
    public void ChangeMiss(float bonusMiss)
    {
        miss += bonusMiss;
        if(miss>maxMiss)
            miss = maxMiss;
    }
    public void ChangeFireCoof(float bonusCoofFire)
    {
        _coofFireDamage *= bonusCoofFire;
        SetDamageFireAndToxic();
    }
    public void ChangeToxicCoof(float bonusCoofToxic)
    {
        _coofToxicDamage *= bonusCoofToxic;
        SetDamageFireAndToxic();
    }
    public void ChangeForwardCountBullet(int newCountBullet)
    {
        countBullet = newCountBullet;
        if(countBullet>3)
            countBullet = 3;
    }

    public void ChangeDopCountBullet()
    {
        dopCountBullet++;
        if (dopCountBullet > maxDopCountBullet)
        {
            dopCountBullet = maxDopCountBullet;
        }
    }
    public void ChangeHealsPerLevel(int bonusHealsPerLevel)
    {
        healsPerLevel+=bonusHealsPerLevel;
        SetHP(healsPerLevel, false);
    }

    public void ChangeDopGold(float dopCoofDropGold)
    {
        _dopGoldPR+=dopCoofDropGold;
    }
     public void ChangeDopDiamod(float dopCoofDropDiamond)
    {
        _dopDropDiamondPR+= dopCoofDropDiamond;
    }
    public void ChangeDopExpa(float dopCoofDropExpa)
    {
        _dopExpPR += dopCoofDropExpa;
    }
     public void ChangeDopPart(float dopCoofDropPart)
    {
        _dopPrDropPart += dopCoofDropPart;
    }



    #endregion
}
