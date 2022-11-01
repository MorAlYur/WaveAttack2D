using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHeart : MonoBehaviour
{
    private ManagerHPPlayer _managerHPPlayer;
    private Transform _tPlayer;
    public float visotaYPlayer;
    public float speed;
    public int _helsCountPlayer;

    void Start()
    {
        _managerHPPlayer = GameObject.FindObjectOfType<ManagerHPPlayer>();
        _tPlayer = _managerHPPlayer.gameObject.transform;// GameObject.FindObjectOfType<ManagerHPPlayer>().transform;
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_tPlayer.position.x, _tPlayer.position.y + visotaYPlayer, _tPlayer.position.z), Time.deltaTime * speed);

        if (transform.position == new Vector3(_tPlayer.position.x, _tPlayer.position.y + visotaYPlayer, _tPlayer.position.z))
        {
            _managerHPPlayer.SetHP(_helsCountPlayer, false);
            Destroy(gameObject);
        }
    }
    public void SetHelsCountPlayer(int hels)
    {
        _helsCountPlayer = hels;
    }
   
}
