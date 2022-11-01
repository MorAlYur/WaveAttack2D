using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryLevel1_2 : MonoBehaviour
{
    [SerializeField] Factory _factory;
    [SerializeField] private LevelSetting _prefabLevel;
    [SerializeField] private List<Enemy> _enemiesLevel;
    public void InstanseAllScene()
    {
        _factory.InstanseLevel(_prefabLevel);

        foreach (var enemy in _enemiesLevel)
        {
            _factory.InstanseEnemy(enemy, enemy.transform.position);
        }
    }

}
