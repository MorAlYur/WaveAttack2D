using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestMovientSpeed : MonoBehaviour
{
    public PlayerMove _playerMove;
    public Rigidbody2D _rigidbody2DPlayer;

    public TMP_InputField _iMovSpeed;
    public TMP_InputField _iJumpForse;
    public TMP_InputField _iJumpTime;
    public TMP_InputField _iGravitiScale;
    public TMP_InputField _iTakeDamage;




    void Start()
    {
        _iMovSpeed.text = _playerMove.speed.ToString();
        _iJumpForse.text = _playerMove.forseJump.ToString();
        _iJumpTime.text = _playerMove.maxTimeJump.ToString();
        _iGravitiScale.text = _rigidbody2DPlayer.gravityScale.ToString();
        _iTakeDamage.text = _playerMove.forsJumpTakeDamoge.ToString();
        
    }

    public void SetSpeed()
    {
        _playerMove.speed = float.Parse(_iMovSpeed.text);
    }
    public void SetJump()
    {
        _playerMove.forseJump = float.Parse(_iJumpForse.text);
        _playerMove.maxTimeJump = float.Parse(_iJumpTime.text);
        _rigidbody2DPlayer.gravityScale = float.Parse(_iGravitiScale.text);
    }

    public void SetTakeDamage()
    {
        _playerMove.forsJumpTakeDamoge = float.Parse(_iTakeDamage.text);
    }
}
