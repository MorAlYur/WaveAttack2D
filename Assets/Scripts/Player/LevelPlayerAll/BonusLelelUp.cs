using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusLelelUp : MonoBehaviour
{
    public LevelPlayer _levelPlayer;
    public LevelUpMenu _levelUpMenu;
    public ManagerHPPlayer _managerHPPlayer;
    public PlayerMove _playerMove;
    public Atack _atack;
    public PoolBullet _poolBullet;


    public void ClicButtonLevelUITru()
    {
        _levelPlayer.clicButtonBonus = true;
        _levelUpMenu.GoSetActiv(false);
    }

    public void BonDamage()
    {
        _managerHPPlayer.damage =(int)(_managerHPPlayer.damage* 1.25f);
        ClicButtonLevelUITru();
    }
    public void BonHeals()
    {
        int newMaxHP = (int)(_managerHPPlayer.maxHP * 1.25f);
        int changeeHP = newMaxHP - _managerHPPlayer.maxHP;
        _managerHPPlayer.SetMaxHP(newMaxHP, 0, false);
        _managerHPPlayer.SetHP(changeeHP, false);
        ClicButtonLevelUITru();
    }
    public void BonShild()
    {
        int newMaxShild = (int)(_managerHPPlayer.maxShild * 1.25f);
        int changeeChild = newMaxShild-_managerHPPlayer.maxShild;
        _managerHPPlayer.SetMaxShild(newMaxShild, 0, false);
        _managerHPPlayer.SetShild(changeeChild,false);
        ClicButtonLevelUITru();
    }
    public void BonAttackSpeed()
    {
        _atack.attacTimeSpeed = _atack.attacTimeSpeed * 1.2f;
        ClicButtonLevelUITru();
    }
    public void BonIsFire1()
    {
        _managerHPPlayer.isFire = true;
        ClicButtonLevelUITru();
    }
    public void BonIsFire2()
    {
        _managerHPPlayer.damageFire = (int)(_managerHPPlayer.damageFire * 1.5);
        ClicButtonLevelUITru();
    }
    public void BonIsFire3()
    {
        _managerHPPlayer.damageFire = (int)(_managerHPPlayer.damageFire * 1.5);
        ClicButtonLevelUITru();
    }
    public void BonIsToxic1()
    {
        _managerHPPlayer.isToxic = true;
        ClicButtonLevelUITru();
    }
    public void BonIsToxic2()
    {
        _managerHPPlayer.damageToxic = (int)(_managerHPPlayer.damageToxic * 1.5);
        ClicButtonLevelUITru();
    }
    public void BonIsToxic3()
    {
        _managerHPPlayer.damageToxic = (int)(_managerHPPlayer.damageToxic * 1.5);
        ClicButtonLevelUITru();
    }
    public void BonSkvoznieBullet()
    {
        _managerHPPlayer.skvozniePuli = true;
        ClicButtonLevelUITru();
    }
    public void BonRikoshetBullet()
    {
        _managerHPPlayer.rikoshetPuli = true;
        ClicButtonLevelUITru();
    }
    public void BonJumpBullet()
    {
        _managerHPPlayer.jumpPuli = true;
        ClicButtonLevelUITru();
    }
    public void BonAddNewBullet()
    {
        _managerHPPlayer.addNewPuli = true;
        ClicButtonLevelUITru();
    }
    public void BonMovientSpeed()
    {
        _playerMove.speed = _playerMove.speed * 1.5f;
        ClicButtonLevelUITru();
    }
    public void BonJump()
    {
        _playerMove.maxJump = 3;
        ClicButtonLevelUITru();
    }
    public void BonBulletDuble()
    {
        _managerHPPlayer.countBullet = 2;
        ClicButtonLevelUITru();
    }
    public void BonBulletTriple()
    {
        _managerHPPlayer.countBullet = 3;
        ClicButtonLevelUITru();
    }
    public void BonBullet180()
    {
        _managerHPPlayer.bullet180 = true;
        ClicButtonLevelUITru();
    }
    public void BonBullet90()
    {
        _managerHPPlayer.bullet90 = true;
        ClicButtonLevelUITru();
    }
    public void BonDopBullet()
    {
        _managerHPPlayer.dopCountBullet++;
        ClicButtonLevelUITru();
    }
    public void BonArmor()
    {
        _managerHPPlayer.armor = (int)(_managerHPPlayer.armor +30);
        ClicButtonLevelUITru();
    }
    public void BonCridChanse()
    {
        _managerHPPlayer.critChanse += 10;
        ClicButtonLevelUITru();
    }
    public void BonCritDamage()
    {
        _managerHPPlayer.critDamage += 100;
        ClicButtonLevelUITru();
    }
    public void BonFirstAid()
    {
        _managerHPPlayer.healsPerLevel += 200;
        ClicButtonLevelUITru();
    }
    public void BonVolley()
    {
        _managerHPPlayer.dubleShot = true;
        ClicButtonLevelUITru();

    }
    public void BonMiss()
    {
        _managerHPPlayer.miss += 5;
        ClicButtonLevelUITru();
    }
    public void BonMaster()
    {
        int newMaxHP = (int)(_managerHPPlayer.maxHP * 1.1f);
        int changeeHP = newMaxHP - _managerHPPlayer.maxHP;
        _managerHPPlayer.SetMaxHP(newMaxHP, 0, false);
        _managerHPPlayer.SetHP(changeeHP, false);

        int newMaxShild = (int)(_managerHPPlayer.maxShild * 1.1f);
        int changeeChild = newMaxShild - _managerHPPlayer.maxShild;
        _managerHPPlayer.SetMaxShild(newMaxShild, 0, false);
        _managerHPPlayer.SetShild(changeeChild, false);

        _managerHPPlayer.damage = (int)(_managerHPPlayer.damage * 1.1f);

        ClicButtonLevelUITru();

    }
    public void BonCritMaster()
    {
        _managerHPPlayer.critChanse += 5;
        _managerHPPlayer.critDamage += 50;
        ClicButtonLevelUITru();
    }
    public void BonGold()
    {
        _managerHPPlayer._dopGoldPR += 50;
        ClicButtonLevelUITru();
    }
    public void BonExp()
    {
        _managerHPPlayer._dopGoldPR += 50;
        ClicButtonLevelUITru();
    }
    public void BonDimond()
    {
        _managerHPPlayer._dopDropDiamondPR += 20;
        ClicButtonLevelUITru();
    }
    public void BonVampiric()
    {
        _managerHPPlayer.isVampiric = true;
        ClicButtonLevelUITru();
    }

    public void BonSpeedBullet()
    {
        _poolBullet.SetSpeedBullet(1.5f);
        ClicButtonLevelUITru();
    }
}
