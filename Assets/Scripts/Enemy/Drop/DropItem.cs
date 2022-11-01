using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class DropItem : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Transform _tPlayer;
    private bool _isFlying;

    public SpriteRenderer _sprite;
    public TMP_Text _textName;
    public Vector2 force;
    public float visotaYPlayer;
    public float timeZad;
    public float speed;
    
    
   


    private void Start()
    {
        _tPlayer = GameObject.FindObjectOfType<ManagerHPPlayer>().transform;
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(Random.Range(-0.5f,0.5f),1f)* force, ForceMode2D.Impulse);
        Invoke("Fly", timeZad);

    }
    private void Update()
    {

        if (_isFlying == true)
        {
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(_tPlayer.position.x,_tPlayer.position.y+ visotaYPlayer, _tPlayer.position.z), Time.deltaTime * speed);
        }
        if (transform.position == new Vector3(_tPlayer.position.x, _tPlayer.position.y + visotaYPlayer, _tPlayer.position.z))
        {
            Destroy(gameObject);
        }
        
    }
    public void SetParametr(string name,Sprite image)
    {
        SetName(name);
        SetSprite(image);
    }
    public void SetName(string name)
    {
        _textName.text = name;
    }
    public void SetSprite(Sprite image)
    {
        _sprite.sprite = image;
    }

    private void Fly()
    {
        _rigidbody2D.simulated = false;
        _isFlying = true;
    }
}
