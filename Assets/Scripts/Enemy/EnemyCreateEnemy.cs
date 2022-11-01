using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreateEnemy : MonoBehaviour
{
    public delegate void CreateEnemyDelegate(Enemy enemy,Vector3 position);
    public event CreateEnemyDelegate CreateEnemyEvent;
    [SerializeField]
    private bool _spawnEnemy = false; 
    [SerializeField]
    private List<Enemy> _enemiesSpawn;
    [SerializeField]
    private bool _isSpawnAllEnemySpawn;
    [SerializeField]
    private List<int> _indexSpawnEnemy; 

    public void CreateEnemyDead()
    {
        if (_spawnEnemy == false)
        {
            return;
        }

        if (_isSpawnAllEnemySpawn)
        {
            foreach (var enemy in _enemiesSpawn)
            {
                CreateEnemyEvent?.Invoke(enemy, gameObject.transform.position);
            }
        }
        else
        {
            foreach (var index in _indexSpawnEnemy)
            {
                if (index > _enemiesSpawn.Count)
                {
                   
                }
                else
                {
                    CreateEnemyEvent?.Invoke(_enemiesSpawn[index], gameObject.transform.position);
                }
            }
        }
    }
}
