using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Atack : MonoBehaviour
{

    public GameObject prefabPula;
    public Transform mestoSpawna;

    public TargetSystem targetSystem;
    public PoolBullet poolBullet;

    public float attacTimeSpeed;
    [Inject]
    public ItemSingolton _itemSingolton;

    private void Start()
    {
        StartCoroutine(AttackCor());
        attacTimeSpeed =_itemSingolton._allAttackSpeed;
    }

    IEnumerator AttackCor()
    {
        while (true)
        {
            if (targetSystem.currentTarget == null)
                yield return null;
            else
            {
                Attack();
                yield return new WaitForSeconds(1 / attacTimeSpeed);
            }
        }
    }
    public void Attack()
    {
        poolBullet.ActiveBullet();      
    }  
}
