using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EmenyHPManager))] 

public class EnemyMeleeAttack : MonoBehaviour
{
    public int _meleeAttack;

    private void Start()
    {
        _meleeAttack = gameObject.GetComponent<EmenyHPManager>().damageMele;
    }
}
