using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsNull))]
[RequireComponent(typeof(ManualActivationTransition))]

public class EnemyStateMashine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    [SerializeField] private Player _target;
    private State _curentState;

    public State Curent => _curentState;

    public void Start()
    {
        _target = FindObjectOfType<Player>(); 
        Reset(_firstState);
    }
    private void Update()
    {
        if (_curentState == null)
            return;
        var nextState = _curentState.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }
    private void Reset(State startState)
    {
        _curentState = startState;

        if (_curentState != null)
            _curentState.Enter(_target);
    }
    private void Transit(State nextState)
    {
        if (_curentState != null)
            _curentState.Exit();

        _curentState = nextState;

        if (_curentState != null)
            _curentState.Enter(_target);
    }

}
