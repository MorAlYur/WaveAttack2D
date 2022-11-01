using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public PoolEnemyBulletState1 _poolEnemyBulletState1;

    public void InstallingDependencies(PoolEnemyBulletState1 poolEnemyBulletState1)
    {
        _poolEnemyBulletState1 = poolEnemyBulletState1;
    }

}
