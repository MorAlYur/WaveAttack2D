using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRenderCamera))]
public class RenderCameraOFF : Transition
{
    [SerializeField] private float _time;

    private EnemyRenderCamera _enemyRenderCamera;
    private float _timer;
    private bool _startTimer;

    private void Awake()
    {
        _enemyRenderCamera = gameObject.GetComponent<EnemyRenderCamera>();
        _enemyRenderCamera.OnEnemyInvisibleEvent += IsInvisible;
       // _enemyRenderCamera.OnEnemyVisibleEvent += IsVisible;
    }

    

    private void OnEnable()
    {
        if (_enemyRenderCamera._isVisible == false)
        {
            _startTimer = true;
        }
    }
    private void Update()
    {
        if (_startTimer == true)
        {
            _timer += Time.deltaTime;
            if (_timer >= _time)
            {
                NeedTransit = true;
            }
        }
    }
    private void OnDisable()
    {
        _startTimer = false;
        _timer = 0;
        NeedTransit = false;
    }
    private void IsInvisible(Transform transform)
    {
        _startTimer = true;
    }
    //private void IsVisible()
    //{
    //    NeedTransit = true;
    //    Debug.Log(11111111111);
    //}
}
