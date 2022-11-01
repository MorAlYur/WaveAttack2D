using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CameraController : MonoBehaviour
{
    private float _xOfsetClamp;
    private float _yOfsetClamp;
    public float dumping = 1.5f; // сглаживание
    public Vector2 offset = new Vector2(2f, 1f);
    public bool isLeft;
    private Transform player;
    private int lastX;
    public GameObject rightLimit;
    public GameObject leftLimit;
    public GameObject upLimit;
    public GameObject downLimit;



    void Start()
    {
        
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);   
        FindPlayer(isLeft);
        SetScreenClampOfset();

    }
    public void FindLimit(GameObject righrLimtt, GameObject leftLimitt, GameObject upLimitt,GameObject downLimitt)
    {
        rightLimit = righrLimtt;
        leftLimit = leftLimitt;
        upLimit = upLimitt;
        downLimit = downLimitt;
    }
    public void FindPlayer(bool playerIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerIsLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    
    }

    private void FixedUpdate() 
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) isLeft = false;
            else if (currentX < lastX) isLeft = true;
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (isLeft)
            {
              target =  new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
              target =  new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping);
            transform.position = currentPosition;
        }


        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit.transform.position.x + _xOfsetClamp, rightLimit.transform.position.x - _xOfsetClamp),
            Mathf.Clamp(transform.position.y, downLimit.transform.position.y + _yOfsetClamp, upLimit.transform.position.y - _yOfsetClamp),
            transform.position.z
            );

    }
    public void SetScreenClampOfset()
    {

        var min = gameObject.GetComponent<Camera>().ViewportToWorldPoint(new Vector2(0, 0));
        var max = gameObject.GetComponent<Camera>().ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        _xOfsetClamp = max.x - min.x;
        _yOfsetClamp = max.y - min.y;
        
    }

   
}
