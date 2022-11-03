using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Atack : MonoBehaviour
{

    public TargetSystem targetSystem;


   [SerializeField] private PlayerPoolsBullet _activPoolBulet; 

    public float attacTimeSpeed;
    [Inject]
    public ItemSingolton _itemSingolton;

    private void Start()
    {
        

        StartCoroutine(AttackCor());
        attacTimeSpeed =_itemSingolton._allAttackSpeed;
    }
    public void SetPoolBullet(PlayerPoolsBullet playerPoolsBullet)
    {
        _activPoolBulet = playerPoolsBullet;
    }
    IEnumerator AttackCor()
    {
        yield return null;  
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
        _activPoolBulet.ActivateBullet();     
        
    }  
}
