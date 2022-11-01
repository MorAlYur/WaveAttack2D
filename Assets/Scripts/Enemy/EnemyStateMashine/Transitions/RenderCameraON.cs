using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyRenderCamera))]

public class RenderCameraON : Transition
{
    private EnemyRenderCamera _enemyRenderCamera;

    private void Awake()
    {
        _enemyRenderCamera = gameObject.GetComponent<EnemyRenderCamera>();
        _enemyRenderCamera.OnEnemyVisibleEvent += IsVisible;
    }
    private void OnEnable()
    {
        if (_enemyRenderCamera._isVisible == true)
        {
            NeedTransit = true;
        }
    }
    private void IsVisible(Transform transform)
    {
        NeedTransit = true;
    }
    private void OnDisable()
    {
        NeedTransit = false;
    }
}
