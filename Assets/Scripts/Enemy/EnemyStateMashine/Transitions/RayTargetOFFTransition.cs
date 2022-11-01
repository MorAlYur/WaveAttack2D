using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyRenderCamera))]
public class RayTargetOFFTransition : Transition
{
    [SerializeField] private LayerMask _layerMaskFindPlayer;
    [SerializeField] private float _distanceVisibility;
    [SerializeField] private float _timeRayCast;
    [SerializeField] private Vector3 _centrPlayer;
    [SerializeField] private Transform _buletSpavn;

    private EnemyRenderCamera _enemyRenderCamera;
    private float _time;

    private void Awake()
    {
        _enemyRenderCamera = gameObject.GetComponent<EnemyRenderCamera>();
        _enemyRenderCamera.OnEnemyInvisibleEvent += IsInvisible;
    }

    

    void Update()
    {
        if (enabled == false)
            return;

        if (Vector3.Distance(Target.transform.position, transform.position) > _distanceVisibility)
        {
            NeedTransit = true;
        }
        else
        {
            _time += Time.deltaTime;
            if (_time >= _timeRayCast)
            {
                RayCast();
                _time = 0;
            }
        }
    }
    public void RayCast()
    {

        RaycastHit2D hit2D = Physics2D.Raycast(_buletSpavn.position, (Target.transform.position + _centrPlayer - _buletSpavn.position), _distanceVisibility, _layerMaskFindPlayer);
        if (hit2D)
        {
            if (!hit2D.collider.TryGetComponent<Player>(out Player player))
            {
                NeedTransit = true;
            }
        }
    }

    private void IsInvisible(Transform transform)
    {
           NeedTransit = true;
    }

    private void OnDisable()
    {
        NeedTransit = false;
    }
}
