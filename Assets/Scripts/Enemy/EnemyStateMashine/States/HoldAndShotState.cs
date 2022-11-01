using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(EnemyIsRight))]
[RequireComponent(typeof(EmenyHPManager))]


public class HoldAndShotState : State
{
    [SerializeField] private EnemyHPBar _enemyHPBar;
    [SerializeField] private EnemyIsRight _enemyIsRight;
    [SerializeField] private Enemy _enemy; 
    [SerializeField] private EmenyHPManager _emenyHPManager;
    [SerializeField] private EnemyTargetIKManager _targetIKManager;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private float _timeAttack;
    [SerializeField] private int _damage;

    private PoolEnemyBulletState1 _poolEnemyBulletState1;
    private float _time = 0;

    private void OnEnable()
    {
        if (_targetIKManager)
        {
            _targetIKManager._isActiv = true;
        }
    }
    void Start()
    {
        _poolEnemyBulletState1 = _enemy._poolEnemyBulletState1;
        _damage = _emenyHPManager.damageRange;
    }
    

    void Update()
    {
        _time += Time.deltaTime;
        SetIsRight();

        if (_time >= _timeAttack)
        {
            Attack();
        }
    }

    private void Attack()
    {
        _time = 0;
        _poolEnemyBulletState1.Activate(_spawnBullet.position, _enemyIsRight.IsRight, Target.transform,_damage);

    }
    private void SetIsRight()
    {

        if (Target.transform.position.x < transform.position.x && _enemyIsRight.IsRight == true)
        {
            Rot();
        }
         if (Target.transform.position.x > transform.position.x && _enemyIsRight.IsRight == false)
        {
            Rot();
        }
    }
    private void Rot()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _enemyIsRight.Rot();
        _enemyHPBar.Rot();
    }

    private void OnDisable()
    {
        if (_targetIKManager)
        {
            _targetIKManager._isActiv = false;
        }
    }
}
