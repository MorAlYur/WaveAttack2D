using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<EmenyHPManager> _allEnemy;

    public List<Transform> _displayEnemy;

    public event Action<int> _takeDamageEnemy;

    private void OnEnable()
    {
        EmenyHPManager.AddEnemyEvent += AddAllEnemy;
    }

    private void AddAllEnemy(EmenyHPManager enemy)
    {
        _allEnemy.Add(enemy);
        enemy._takeDamageEnemyEvent += TakeDamageEnemy;
        enemy.GetComponent<EnemyRenderCamera>().OnEnemyVisibleEvent += AddDisplayEnemy;
        enemy.GetComponent<EnemyRenderCamera>().OnEnemyInvisibleEvent += RemoveDisplayEnemy;
    }
    private void RemoveAllEnemy(EmenyHPManager enemy)
    {
        _allEnemy.Remove(enemy);
        enemy._takeDamageEnemyEvent -= TakeDamageEnemy;
        enemy.GetComponent<EnemyRenderCamera>().OnEnemyVisibleEvent -= AddDisplayEnemy;
        enemy.GetComponent<EnemyRenderCamera>().OnEnemyInvisibleEvent -= RemoveDisplayEnemy;
    }
    private void AddDisplayEnemy(Transform transform)
    {
        _displayEnemy.Add(transform);
    }
    private void RemoveDisplayEnemy(Transform transform)
    {
        _displayEnemy.Remove(transform);
    }
    private void TakeDamageEnemy(int value)
    {
        _takeDamageEnemy?.Invoke(value);
    }
    private void OnDisable()
    {
        //foreach (var emeny in _allEnemy)
        //{

        //}
    }
}
