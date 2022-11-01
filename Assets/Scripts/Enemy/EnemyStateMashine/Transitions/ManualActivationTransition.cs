using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ManualActivationTransition : Transition
{
    [SerializeField] private int _timeToActivationMilisecond = 200;
    private void Start()
    {
        ActivateTransition();
    }
    public async void ActivateTransition()
    {
        await Task.Delay(_timeToActivationMilisecond);
        NeedTransit = true;
    }

    private void OnDisable()
    {
        NeedTransit = false;
    }
}
