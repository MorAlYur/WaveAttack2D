using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Zenject;

public class Atack : MonoBehaviour
{

    public TargetSystem targetSystem;
    [SerializeField] private PlayerPoolsBullet _activPoolBulet;
    [SerializeField] private ManagerHPPlayer _managerHPPlayer;
    [SerializeField] private Factory _factory;
    [SerializeField] private float _radiusBang;
    [SerializeField] private LayerMask _layerEnemy; 

    private void OnEnable()
    {
        _factory.KillEnemy += Bang;
    }
    private void OnDisable()
    {
        _factory.KillEnemy -= Bang;
    }

    
    private void Start()
    {
        

        StartCoroutine(AttackCor());

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
                yield return new WaitForSeconds(1 / _managerHPPlayer.attackSpped);
            }
        }
    }
    public void Attack()
    {
        _activPoolBulet.ActivateBullet();     
        
    }
    private async void Bang(Vector3 position)
    {
        await Task.Delay(1);
        if(!_managerHPPlayer.bangNormal&&! _managerHPPlayer.bangFire&& !_managerHPPlayer.bangToxic)
        {
            return;
        }
        int coof = 0;
        if (_managerHPPlayer.bangNormal)
        {
            coof++;
        }
        if (_managerHPPlayer.bangFire)
        {
            coof++;
        }
        if (_managerHPPlayer.bangToxic)
        {
            coof++;
        }
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(position, _radiusBang, _layerEnemy);
        if (collider2D.Length > 0)
        {
            foreach (Collider2D col in collider2D)
            {
                if (col.TryGetComponent<EmenyHPManager>(out EmenyHPManager enemyHpManager))
                {
                    enemyHpManager.TakeDamage(_managerHPPlayer.damage * coof, _managerHPPlayer.bangFire, _managerHPPlayer.bangToxic, false);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,_radiusBang);
    }
}
