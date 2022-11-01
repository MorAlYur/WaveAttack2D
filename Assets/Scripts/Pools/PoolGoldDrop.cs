using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolGoldDrop : MonoBehaviour
{
    public int poolCount;
    public bool autoExpant;
    public DropGold prefabGoldDrop;

    public PoolMono<DropGold> pool;
    
    void Start()
    {
        pool = new PoolMono<DropGold>(prefabGoldDrop, poolCount,transform);
        pool.autoExpand = autoExpant;
    }

    public void Activate(Vector3 pos)
    {
        var gold = pool.GetFreeElement(pos);
        gold.Activate();
    }

}
