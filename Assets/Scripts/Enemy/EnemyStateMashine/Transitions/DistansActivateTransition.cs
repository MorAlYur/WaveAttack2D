using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistansActivateTransition : Transition
{
    [SerializeField] private float _distanseActivate=25;
    void Update()
    {
        var dis = Vector3.Distance(Target.transform.position, transform.position);
        if (dis < _distanseActivate)
        {
            NeedTransit = true;
        }
    }

    
}
