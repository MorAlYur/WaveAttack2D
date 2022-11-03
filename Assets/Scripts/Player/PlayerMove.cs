using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerMove : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public float speed;
    public float forseJump;
    public float horizont;
    public float vertical;
    public Joystick joystick;
    public float startTimeJump;
    public float maxTimeJump;
    public bool Jump;
    public int scetJump;
    public int maxJump=2;

    public float forsJumpTakeDamoge;

    private int layerPlayer, layerPlatform;
    private TargetSystem targetSystem;

    public Animator animator;

    private bool start = true;

    private ManagerHPPlayer _managerHPPlayer;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        layerPlayer = LayerMask.NameToLayer("Player");
        layerPlatform = LayerMask.NameToLayer("Platform");

        targetSystem = gameObject.GetComponent<TargetSystem>();

        _managerHPPlayer = gameObject.GetComponent<ManagerHPPlayer>();
        _managerHPPlayer.TakeDamage1 += JumpToTakeDamage;
       
    }
    private void OnDisable()
    {
        _managerHPPlayer.TakeDamage1 -= JumpToTakeDamage;
    }
    public void SetAnimator(Animator animatorr)
    {
        animator = animatorr;
    }
    private void JumpToTakeDamage(int obj)
    {
        rb.Sleep();
        rb.AddForce(Vector3.up * forsJumpTakeDamoge, ForceMode2D.Impulse);
    }
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void FixedUpdate()
    {
        if (joystick.Horizontal >= 0.15f)
        {
            horizont = 1;
        }
        else if (joystick.Horizontal <= -0.15f)
        {
            horizont = -1;
        }
        else if (joystick.Horizontal < 0.15f && joystick.Horizontal > -0.15f)
        {
            horizont = 0;
        }
        vertical = joystick.Vertical;

#if UNITY_EDITOR_64
        KeybardController();
#endif



        if (start)
        { 
            horizont = 0.001f;
            start = false;
        }
        gameObject.transform.Translate(Vector3.right * speed * horizont);


        if (Jump)
        {
            if (startTimeJump++ < maxTimeJump)
            {
                rb.velocity = Vector2.up * forseJump;
                
            }
           

        }
        else
            startTimeJump = 0;

    }
   
    private void Update()
    {
        if (vertical <= -0.8)
            Physics2D.IgnoreLayerCollision(layerPlayer, layerPlatform, true);       
        else
            Physics2D.IgnoreLayerCollision(layerPlayer, layerPlatform, false);

        if (horizont != 0&& rb.velocity.y == 0)
        {
            //animator.SetBool("isRun", true);
            if (targetSystem.IsRight == true && horizont > 0)
            {
                animator.SetBool("isRun", true);
                animator.SetBool("isRunBack", false);
            }
            else if (targetSystem.IsRight == true && horizont < 0)
            {
                animator.SetBool("isRun", false);
                animator.SetBool("isRunBack", true);
            }
           else if (targetSystem.IsRight == false && horizont > 0)
            {
                animator.SetBool("isRun", false);
                animator.SetBool("isRunBack", true);
            }
            else if (targetSystem.IsRight == false && horizont < 0)
            {
                animator.SetBool("isRun", true);
                animator.SetBool("isRunBack", false);
            }
           
        }
        else
        {
            animator.SetBool("isRun", false);
            animator.SetBool("isRunBack", false);
        }
        if (rb.velocity.y != 0)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }
    public void KeybardController()
    {
        if (Input.GetKey(KeyCode.A))
        {
            horizont = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizont = 1;
        }
        else
        {
            horizont = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
        }
        else
        {
            vertical = 0;
        }
    }

    public void Jumper()
    {
        
    }
    public void StartJump()
    {
        if (scetJump < maxJump)
        {
            rb.Sleep();           
            Jump = true;
            scetJump++;
        }

    }
    public void StopJump()
    {
        Jump = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.TryGetComponent<Platform>(out Platform platform)||collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            scetJump = 0;

        }

    }
    
   

   
   
   
    
}
