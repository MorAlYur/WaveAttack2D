using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Бег от стены до стены
// Run in wall

[RequireComponent(typeof(EnemyIsRight))]

public class MoveState1 : State
{

    private EnemyHPBar _enemyHPBar;
    private EnemyIsRight _enemyIsRight;
    

    [SerializeField] private float _speed;

    private void Start()
    {
        _enemyIsRight = GetComponent<EnemyIsRight>();
        _enemyHPBar = GetComponentInChildren<EnemyHPBar>();

    }  
    private void Update()
    {
       

        if (_enemyIsRight.IsRight)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        else if (!_enemyIsRight.IsRight)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
    }
    private void Rot()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _enemyIsRight.Rot();
        _enemyHPBar.Rot();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enabled == false)
            return;
        if (collision.gameObject.TryGetComponent(out Player player) || collision.gameObject.TryGetComponent(out Enemy enemy) || collision.gameObject.TryGetComponent(out Wall wall))
            Rot();
    }
}
