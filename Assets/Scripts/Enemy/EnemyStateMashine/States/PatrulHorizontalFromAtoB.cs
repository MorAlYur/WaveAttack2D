using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrulHorizontalFromAtoB : State
{
    private int i=1;

    [SerializeField] private EnemyHPBar _enemyHPBar;
    [SerializeField] private EnemyIsRight _enemyIsRight;
    [SerializeField] private float speed;
    [SerializeField] private float[] _wayPointX;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _animator.SetBool("isRun", true);
        if (_wayPointX[i] > transform.position.x && _enemyIsRight.IsRight == false)
        {
            Rot();
        }
        if(_wayPointX[i]<transform.position.x && _enemyIsRight.IsRight == true)
        {
            Rot();
        }
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_wayPointX[i],transform.position.y,transform.position.z), speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, new Vector3(_wayPointX[i], transform.position.y, transform.position.z)) <= 0.2){
            Rot();
            SetI();
        }
    }
    private void SetI()
    {
        if (i == _wayPointX.Length-1)
        {
            i = 0;
        }
        else
        {
            i++;
        }
    }
    private void Rot()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _enemyIsRight.Rot();
        _enemyHPBar.Rot();
    }

    private void OnDisable()
    {
        _animator.SetBool("isRun", false);
    }
}
