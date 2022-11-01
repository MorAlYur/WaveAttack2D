using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGold : MonoBehaviour
{
    public Rigidbody2D _rigidbody2D;
    public Transform _tRewardInLevel;
    private bool _isFlying;

    public Vector2 force;
    public float timeZad;
    public float speed;

    private void Start()
    {
        _tRewardInLevel = GameObject.FindObjectOfType<RewardInLevel>().transform;
        
    }
    private void Update()
    {
        if (_isFlying == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _tRewardInLevel.position, Time.deltaTime * speed);
        }
        if (transform.position == _tRewardInLevel.position)
        {
            Deactivate();
        }
    }
    public void Activate()
    {
        gameObject.SetActive(true);
        _rigidbody2D.AddForce(new Vector2(Random.Range(-0.5f, 0.5f), 1f) * force, ForceMode2D.Impulse);
        Invoke("Fly", timeZad);
    }
    public void Deactivate()
    {       
        _rigidbody2D.simulated = true;
        _isFlying = false;
        gameObject.SetActive(false);
    }
    private void Fly()
    {
        _rigidbody2D.simulated = false;
        _isFlying = true;
    }
}
