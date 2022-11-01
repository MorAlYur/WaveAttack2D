using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullett1 : MonoBehaviour
{
    private Vector3 _direction = Vector3.right;
    private Vector3 startPos;
    private int _damage;


    [SerializeField] private float _speed;



    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
        var dis = Vector3.Distance(startPos, transform.position);
        if (Mathf.Abs(dis) > 25)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetRotation(float rot)
    {
        this.transform.eulerAngles = new Vector3(0, 0, rot);

    }
    public void SetPosition(Vector3 position)
    {
        startPos = position;
        transform.position = position;
    }
    public void SetDamage(int damage)
    {
        _damage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ManagerHPPlayer>(out ManagerHPPlayer managerHPPlayer))
        {
            managerHPPlayer.TakeDamag(_damage);
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    
}

