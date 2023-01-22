using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

 [RequireComponent(typeof(EnemyDrop))]
 [RequireComponent(typeof(Enemy))]
 [RequireComponent(typeof(EnemyCreateEnemy))]
 [RequireComponent(typeof(EnemyStartImpulse))]

public class EmenyHPManager : MonoBehaviour
{

    public delegate void TextFlyDelegate(Vector3 position,int value, bool isFire, bool isToxic, bool isCrit, bool isDamage);
    public static event TextFlyDelegate TextFlyEvent;

    public event Action<float> HPBarEvent;

    public delegate void DeadEnemyDelegate(bool isKill,Vector3 position,Enemy enemy);
    public event DeadEnemyDelegate DeadEnemyEvent;

    public static event Action<EmenyHPManager> AddEnemyEvent;
    public event Action<int> _takeDamageEnemyEvent;
    public event Action<Enemy> _deathEnemy;

    private EnemyDrop _enemyDrop;

    private bool isDeat = false;

    [Header("тут задавать")]
    public int maxHP;
    public int HP;
    public int damageRange;
    public int damageMele;
    

    private bool isFireEmeny;
    private bool isToxicEmeny;
    private int startFire;
    private int startToxic;

    private bool isCrit;

    public ManagerHPPlayer _managerHPPlayer;


    public void InstallingDependencies(ManagerHPPlayer managerHPPlayer)
    {
        _managerHPPlayer = managerHPPlayer;
    }
    private void Start()
    {
        _enemyDrop = gameObject.GetComponent<EnemyDrop>();
        AddEnemyEvent?.Invoke(this);
        
    }
    public void SetHP(int value,bool isFire,bool isToxic,bool isCrit,bool isDamage)
    {
        if (isDamage)
        {
            HP -= value;
            TextFlyEvent?.Invoke(transform.position, value, isFire, isToxic, isCrit, isDamage);
            _takeDamageEnemyEvent?.Invoke(value);
        }
        else
        {
            HP += value;
        }
        SetFillAmoutHP();

        if (HP <= 0)
        {
            Delete();
        }
    }
   
    public void SetFillAmoutHP()
    {
        HPBarEvent?.Invoke((float)HP / maxHP);
    }
    public void TakeDamage()
    {
        TakeDamage(_managerHPPlayer.damage, _managerHPPlayer.isFire, _managerHPPlayer.isToxic, true);
    }
    public void TakeDamage(int damage,bool isFire,bool isToxic,bool possibleIsCrit)
    {
        if (isFire)                //если усиление горящие пули
        {
            startFire = 0;
            if (!isFireEmeny)
            {
                StartCoroutine(FireDamage());
            }
        }
        if (isToxic)                //если усиление ядовитые пули
        {
            startToxic = 0;
            if (!isToxicEmeny)
            {
                StartCoroutine(ToxicDamage());
            }
        }
        if (possibleIsCrit)
        {
            int r = UnityEngine.Random.Range(0, 10000);
            if (r <= ((int)(_managerHPPlayer.critChanse * 100)))
            {
                damage = damage + (int)(damage * (_managerHPPlayer.critDamage * 0.01f) + 1);
                isCrit = true;
            }
            else
            {
                isCrit = false;
            }
        }

        SetHP(damage, false, false, isCrit, true);
        


    }
    IEnumerator FireDamage()        //урон от горения
    {
        isFireEmeny = true;
        for(startFire=0;startFire<=5;startFire++)
        {
            yield return new WaitForSeconds(0.2f);
            SetHP(_managerHPPlayer.damageFire, true, false, false, true);
            yield return new WaitForSeconds(0.3f);
        }
        isFireEmeny = false;
    } 
    IEnumerator ToxicDamage()        //урон от яда
    {
        isToxicEmeny = true;
        for(startToxic=0; startToxic <= 5; startToxic++)
        {
            yield return new WaitForSeconds(0.1f);
            SetHP(_managerHPPlayer.damageToxic, false, true, false, true);
            yield return new WaitForSeconds(0.4f);
        }
        isToxicEmeny = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.TryGetComponent<Pula>(out Pula pula))
        //    TakeDamage(pula.countJumpBull+pula.countRikoshetBull);
        if (collision.TryGetComponent<Bullet>(out Bullet bullet))
            TakeDamage();

    }
    public void Delete()
    {
        if (isDeat == false)
        {
            _enemyDrop.Deat();
            GetComponent<EnemyCreateEnemy>().CreateEnemyDead();
            DeadEnemyEvent?.Invoke(true,transform.position, gameObject.GetComponent<Enemy>());
            
            isDeat = true;
        }
        isDeat = true;
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        DeadEnemyEvent?.Invoke(false, transform.position, gameObject.GetComponent<Enemy>());
    }
}
