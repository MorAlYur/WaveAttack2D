using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyIsRight))]
[RequireComponent(typeof(EnemyRenderCamera))]

public class RayTargetONTransition : Transition
{
    [SerializeField] private LayerMask _layerMaskFindPlayer;
    [SerializeField] private float _distanceVisibility;
    [SerializeField] private float _timeRayCast;
    [SerializeField] private Vector3 _centrPlayer;
    [SerializeField] private Transform _buletSpavn;

    private EnemyIsRight _enemyIsRight;
    private EnemyRenderCamera _enemyRenderCamera;

    private float _time;

    private void Awake()
    {
        _enemyRenderCamera = gameObject.GetComponent<EnemyRenderCamera>();
    }
    private void Start()
    {
        _enemyIsRight = GetComponent<EnemyIsRight>();
    }

    void Update()
    {
        if (enabled == false)
            return;

        if (_enemyRenderCamera._isVisible == false)
            return;

        if (Vector3.Distance(transform.position, Target.transform.position) > _distanceVisibility)
            return;

        _time += Time.deltaTime;
        if (_time >= _timeRayCast)
        {
            RayCast();
            _time = 0;
        }
    }
   
    public void RayCast()
    {
        
        RaycastHit2D hit2D = Physics2D.Raycast(_buletSpavn.position, (Target.transform.position + _centrPlayer - _buletSpavn.position), _distanceVisibility, _layerMaskFindPlayer);
        if (hit2D)
        {
            if (hit2D.collider.TryGetComponent<Player>(out Player player))
            {
                if (_enemyIsRight.IsRight == true)
                {
                    if (transform.position.x < Target.transform.position.x)
                    {
                        NeedTransit = true;
                    }
                }
                else
                {
                    if (transform.position.x > Target.transform.position.x)
                    {
                        NeedTransit = true;
                    }
                }
                
            }
        }
    }
    private void OnDisable()
    {
        NeedTransit = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _distanceVisibility);
    }
}
