using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStartImpulse : MonoBehaviour
{
    [SerializeField] private bool _isAddForcePerStart = false; 
    [SerializeField] private Vector2 _direction;
    void Start()
    {
        if (_isAddForcePerStart == false)
        {
            return;
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(_direction,ForceMode2D.Impulse);
        }
    }

    
}
