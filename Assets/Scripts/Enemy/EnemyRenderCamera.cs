using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRenderCamera : MonoBehaviour
{
    public event Action<Transform> OnEnemyVisibleEvent;
    public event Action<Transform> OnEnemyInvisibleEvent;
    public bool _isVisible;
    private void OnBecameVisible()
    {
        OnEnemyVisibleEvent?.Invoke(gameObject.transform);
        _isVisible = true;
    }

    private void OnBecameInvisible()
    {
        OnEnemyInvisibleEvent?.Invoke(gameObject.transform);
        _isVisible = false;
    }
}
