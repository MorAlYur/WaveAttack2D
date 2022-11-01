using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetIKManager : MonoBehaviour
{
    private Transform _tPlayer;
    private EnemyIsRight _isRightScript;
    public bool _isActiv;
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _ofset;
    

    private void Start()
    {
        _tPlayer = FindObjectOfType<Player>().transform;
        _isRightScript = GetComponent<EnemyIsRight>();
    }

    private void Update()
    {
        if (_isActiv == false)
        {
            if (_isRightScript.IsRight==true)
            {
                _target.transform.position = transform.position + _ofset;
            }
            else
            {
                _target.transform.position = transform.position - _ofset;
            }
        }
        else
        {
            _target.transform.position = _tPlayer.position;
        }
    }
}
