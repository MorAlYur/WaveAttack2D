using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerActivateEnemy : MonoBehaviour
{
    [SerializeField] private List<ManualActivationTransition> _enemys;

    private void Activate()
    {
        foreach (var enemy in _enemys)
        {
            enemy.ActivateTransition();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            Activate();
        }
    }
}
