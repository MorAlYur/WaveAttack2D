using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerHPSliderMove : MonoBehaviour
{
    public Transform _player;
    public Vector3 _pos;
    public Vector3 velocity;
    public float _smoopDumping;


    private void FixedUpdate()
    {
        
        
       // transform.DOMove(_player.position + _pos, _smoopDumping, _snaping);

        //transform.position = Vector3.SmoothDamp(transform.position, _player.position + _pos, ref velocity, _smoopDumping);

        Vector3 curentPosition = Vector3.Lerp(transform.position, _player.position + _pos, _smoopDumping);
        transform.position = curentPosition;

        

        //transform.position = _player.position + _pos;

        //transform.localPosition =  _player.InverseTransformPoint(transform.position);
       
    }
}
