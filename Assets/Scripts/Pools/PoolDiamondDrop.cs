using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDiamondDrop : MonoBehaviour
{
    public int poolCount;
    public bool autoExpant;
    public DropDiamond prefabDiamondDrop;

    public PoolMono<DropDiamond> pool;

    void Start()
    {
        pool = new PoolMono<DropDiamond>(prefabDiamondDrop, poolCount, transform);
        pool.autoExpand = autoExpant;
    }

    public void Activate(Vector3 pos)
    {
        var diamond = pool.GetFreeElement(pos);
        diamond.Activate();
    }
}
