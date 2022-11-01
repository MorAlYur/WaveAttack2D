using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EmenyHPManager))]

public class HP50Transition : Transition
{
    private EmenyHPManager _emenyHPManager;
    void Start()
    {
        _emenyHPManager = GetComponent<EmenyHPManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((float)_emenyHPManager.HP / _emenyHPManager.maxHP <= 0.5f)
        {
            NeedTransit = true;
        }
    }

    private void OnDisable()
    {
        NeedTransit = false;
    }
}
