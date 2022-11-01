using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyFan : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;


    public void Spawn()
    {
        Instantiate(prefab, new Vector3(Random.Range(-9f, 29f), -1f, 0f), Quaternion.identity); //это для кнопки спавна врагов
    }

}
