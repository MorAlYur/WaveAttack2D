using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnemyBulletState1 : MonoBehaviour
{

    public int poolCount;
    public bool autoExpant;
    public EnemyBullett1 prefabPula;

    public PoolMono<EnemyBullett1> pool;
    public Vector3 ofset;

    private void Start()
    {
        pool = new PoolMono<EnemyBullett1>(prefabPula, poolCount,gameObject.transform);
        pool.autoExpand = autoExpant;
    }

    public void Activate(Vector3 position,bool isRight, Transform player,int damage)
    {
        var bull = pool.GetFreeElement(position);
        bull.SetRotation(SetRotate( position,isRight, player));
        bull.SetPosition(position);
        bull.SetDamage(damage);
    }

    private float SetRotate(Vector3 position,bool isRight ,Transform player)
    {
        if (player != null)
        {
            Vector3 direction = new Vector2(player.position.x+ofset.x - position.x, player.position.y+ofset.y - position.y);
            return(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        }
        else
        {
            if(isRight == true)
            {
                return 0;
            }
            else
            {
                return 180;
            }
        }
    }


}
