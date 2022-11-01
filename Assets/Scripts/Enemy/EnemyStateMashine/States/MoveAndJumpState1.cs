using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyIsRight))]

public class MoveAndJumpState1 : State
{
    private int layerEnemy, layerPlatform;
    private Rigidbody2D _rb;
    private float _curentTime;
    private bool _isGronded;
    private EnemyHPBar _enemyHPBar;
    private EnemyIsRight _enemyIsRight;

    [SerializeField] private float _speed;
    [SerializeField] private float _forseJump;
    [SerializeField] private float _timeForse;
    [SerializeField] private float _timeRandomForse;


    private void Start()
    {
        _enemyIsRight = GetComponent<EnemyIsRight>();
        _enemyHPBar = GetComponentInChildren<EnemyHPBar>();
        _timeForse += Random.Range(-_timeRandomForse, _timeRandomForse);
        _rb = GetComponent<Rigidbody2D>();
        layerEnemy = gameObject.layer;
        layerPlatform = LayerMask.NameToLayer("Platform");
        Jump();
    }
    private void Update()
    {
        _curentTime += Time.deltaTime;
        if (_rb.velocity.y > 0)
            Physics2D.IgnoreLayerCollision(layerEnemy, layerPlatform, true);
        else
            Physics2D.IgnoreLayerCollision(layerEnemy, layerPlatform, false);

        if (_enemyIsRight.IsRight)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        else if (!_enemyIsRight.IsRight)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if (_curentTime>_timeForse&&_isGronded==true)
        {
            
            Jump();
            
        }
    }
    private void Rot()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _enemyIsRight.Rot();
        _enemyHPBar.Rot();
    }
    private void Jump()
    {
        _rb.AddForce(Vector3.up*_forseJump, ForceMode2D.Impulse);
        _curentTime = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enabled == false)
            return;
        if (collision.gameObject.TryGetComponent(out Player player) || collision.gameObject.TryGetComponent(out Enemy enemy) || collision.gameObject.TryGetComponent(out Wall wall))
            Rot();
        if (collision.gameObject.TryGetComponent(out Ground ground) || collision.gameObject.TryGetComponent(out Platform platform))
        {
            _isGronded = true;
        }
        
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (enabled == false)
            return;
        if (collision.gameObject.TryGetComponent(out Ground ground) || collision.gameObject.TryGetComponent(out Platform platform))
            _isGronded = false;
    }
}
