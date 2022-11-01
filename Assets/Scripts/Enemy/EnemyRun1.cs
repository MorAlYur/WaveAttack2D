using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyRun1 : MonoBehaviour
{
    public float speed;
    private float posStart;
    private float posFinihs;
    private Rigidbody2D rb;
    private int cadr;
    public float forseJump;
    private int layerEnemy, layerPlatform;
    public bool isRight = true;
    public Image imageHP;






    void Start()
    {
        posStart = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        layerEnemy = LayerMask.NameToLayer("Enemy");
        layerPlatform = LayerMask.NameToLayer("Platform");



    }

  
    void Update()
    {
        if (rb.velocity.y > 0)
            Physics2D.IgnoreLayerCollision(layerEnemy, layerPlatform, true);
        else
            Physics2D.IgnoreLayerCollision(layerEnemy, layerPlatform, false);
    }
    public void Rot()
    {
        transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        isRight = !isRight; 
        //imageHP.rectTransform.localScale = new Vector3(-imageHP.rectTransform.localScale.x, imageHP.rectTransform.localScale.y, imageHP.rectTransform.localScale.z);
    }
    private void FixedUpdate()
    {
        if (isRight)
        {
            transform.Translate(Vector3.right * speed);
        }
        else if(!isRight)
        {
            transform.Translate(Vector3.left * speed);
        }
        posFinihs = transform.position.x;

        if (posStart - posFinihs==0)
        {
            Rot();

        }       
        posStart = posFinihs;


        cadr++;
        if (cadr%150 == 0)
        {
            rb.velocity = Vector2.up * forseJump;
        }
        if (cadr%150 == Random.Range(10,100))
        {
            rb.velocity = Vector2.up * forseJump;
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player)|| collision.gameObject.TryGetComponent(out Enemy enemy)|| collision.gameObject.TryGetComponent(out Wall wall))
            Rot();
       
    }

}
