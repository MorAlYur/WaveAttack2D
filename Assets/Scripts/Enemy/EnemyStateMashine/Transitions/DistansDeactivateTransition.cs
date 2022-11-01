using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistansDeactivateTransition : Transition
{
    public float _timeAway;

    [SerializeField] private float _timeAwayDeaktivate = 10;
    [SerializeField] private float _distanseActivate = 30;
    void Update()
    {
        var dis = Vector3.Distance(Target.transform.position, transform.position);
        if (dis > _distanseActivate)
        {
            _timeAway += Time.deltaTime;
            if (_timeAway >= _timeAwayDeaktivate)
            {
                NeedTransit = true;
            }
        }
    }
}
