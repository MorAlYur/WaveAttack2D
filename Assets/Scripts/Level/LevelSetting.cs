using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetting : MonoBehaviour
{
    [SerializeField] private Portal _curentPortal;
    [SerializeField] private Factory _factory;
    [SerializeField] private GameObject _startPlayerPosipion;
    [SerializeField] private GameObject _leftLimit; 
    [SerializeField] private GameObject _rightLimit; 
    [SerializeField] private GameObject _upLimit; 
    [SerializeField] private GameObject _downLimit; 

    public void InstallingDependencies(Factory factory)
    {
        _factory = factory;
        _factory.NullEnemyEvent += ActivatePortal;
    }

    private void ActivatePortal()
    {
        _curentPortal.ActivatePortal();
    }

    public void LoadNextLevel(Levels nextLevel)
    {
        _factory.LoadLevel(nextLevel);
    }
    public Vector3 GetStartPlayerPosition()
    {
        return _startPlayerPosipion.transform.position;
    }
    public GameObject GetRightLimit()
    {
        return _rightLimit;
    }
     public GameObject GetLeftLimit()
    {
        return _leftLimit;
    }
     public GameObject GetUPLimit()
    {
        return _upLimit;
    }
     public GameObject GetDownLimit()
    {
        return _downLimit;
    }

    private void OnDisable()
    {
        _factory.NullEnemyEvent -= ActivatePortal;
    }

}
