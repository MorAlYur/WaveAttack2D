using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManual : MonoBehaviour
{
    [SerializeField] Factory _factory;
    [SerializeField] private Enemy _chiken1;

    public void SpawnEnemy()
    {
        _factory.InstanseEnemy(_chiken1, new Vector3(Random.Range(0.7f, 33.08f), 4f, 0)); 
    }
    
}
