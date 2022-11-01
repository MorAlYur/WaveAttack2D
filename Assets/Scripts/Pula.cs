using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pula : MonoBehaviour
{
    public static event Action<Vector3,float> newBulletEvent;

    public float speed;
    private Vector3 direction = Vector3.right;
    public Vector3 currentTarget;
    public GameObject curTar;
    private bool isRightMoveDirection;
    private Vector3 startPos;


    public float rotation;

    [Header("для скачущих пуль")]
    public LayerMask layerEmeny; 
    public float rangeFindEmeny;
    public int countJumpBull;
    public int maxCountJumpBull;
    private Collider2D[] colls = new Collider2D[0];

    [Header("для рикошета")]
    public int countRikoshetBull;
    public int maxCountRikoshetBull;
    private Vector3 normal;

    private int layerMaskInRikoshet =1<<9|1<<11;

    [Header("Бонусы")]    
    public bool skvozniePuli;
    public bool jumpPuli;
    public bool rikoshetPuli;
    public bool addNewPuli;

    //private List<Collider2D> collsRay = new List<Collider2D>();   // для прыгающих пули между противниками с использованием лучей
    //private int layer = (1 << 9) | (1 << 13);

    private Vector2 _lastPosition;

    private Transform _lastEnemy;

    private EnemyManager _enemyManager;

    private void Start()
    {
        _enemyManager = FindObjectOfType<EnemyManager>();
    }
    public void SetRotationQaternion(Quaternion quaternion)
    {
        transform.rotation = quaternion;
    }
    public void SetBonus(bool skvoznie, bool jump,bool rikoshet,bool addnewpul)
    {
        skvozniePuli = skvoznie;
        jumpPuli = jump;
        rikoshetPuli = rikoshet;
        addNewPuli = addnewpul;

}
    public void SetCurrentTarget(GameObject currTarget)
    {
        
        if (currTarget != null)
        {
            curTar = currTarget;
            currentTarget = currTarget.transform.position;
        }
    }
    public void SetMoveDirection(bool isRight)
    {
        isRightMoveDirection = isRight;
        startPos = transform.position;
    }
    
    public void SetRotation(float rot)
    {
        this.transform.eulerAngles = new Vector3(0, 0, rot);
    }

    private void FixedUpdate()
    {


        if (rikoshetPuli == true)
        {
            _lastPosition = transform.position;
        }

        transform.Translate(direction * speed);

        var dis = Vector3.Distance(startPos, transform.position);
        if (Mathf.Abs(dis) > 25)
        {
            SetActiveFalse();
        }
    }

    #region для скачущих пуль
    private void ScetCounJumpBull()
    {
        countJumpBull++;
        if (jumpPuli == true)
        {
            if (countJumpBull < maxCountJumpBull)
            {
                GetTargetJumpBulet();

            }
            else
            {
                SetActiveFalse();

            }
        }
        else
        {

        }
    }
    //private void GetTarget()
    //{
    //    colls = new Collider2D[0];
    //    colls = Physics2D.OverlapCircleAll(transform.position, rangeFindEmeny, layerEmeny);
    //    NearTarget();
    //}
    //private void NearTarget()
    //{

    //    Collider2D currentCollider = null;
    //    float dist = Mathf.Infinity;

    //    foreach (Collider2D coll in colls)
    //    {
    //        if (coll.gameObject == curTar)
    //        {
    //            continue;

    //        }
    //        float currentDist = Vector3.Distance(transform.position, coll.transform.position);


    //        if (currentDist < dist)
    //        {

    //            currentCollider = coll;
    //            dist = currentDist;
    //        }


    //    }
    //    if (currentCollider != null)
    //    {
            
    //        currentTarget = currentCollider.gameObject.transform.position;
    //        curTar = currentCollider.gameObject;
    //        SetRotate();

            

    //    }
    //    else if(skvozniePuli==true)
    //    {

    //    }
    //    else
    //    {
    //        SetActiveFalse();

    //    }

    //}

    private void GetTargetJumpBulet()
    {
        float curTargetDistanse = rangeFindEmeny;
        Transform curTargetTransform = null;

        foreach (var tr in _enemyManager._displayEnemy)
        {
            if (tr == _lastEnemy)
            {
                continue;
            }
            if (Vector2.Distance(transform.position, tr.position) > curTargetDistanse)
            {
                continue;
            }
            else
            {
                curTargetTransform = tr;
                curTargetDistanse = Vector2.Distance(transform.position, curTargetTransform.position);
            }
        }
        if (curTargetTransform != null)
        {
            currentTarget = curTargetTransform.position;
            curTar = curTargetTransform.gameObject;
            SetRotate();
        }
        else if(skvozniePuli == true)
        {

        }
        else
        {
            SetActiveFalse();
        }
    }

    private void SetRotate()
    {
        Vector3 direction = new Vector2(currentTarget.x - transform.position.x, currentTarget.y - transform.position.y);
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.eulerAngles = new Vector3(0, 0, rotation); 
    }
    
    #endregion
    #region для рикошета
    private void ScetCountRikoshetBull()
    {
        countRikoshetBull++;
        if (countRikoshetBull < maxCountRikoshetBull)
        {
            Raycact();
            SetRotateRikoshet();
        }
        else
        {
            SetActiveFalse();
        }
    }
    private void SetRotateRikoshet()
    {
        Vector2 reflectDir = Vector2.Reflect(transform.right, normal);
        float rot = Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, rot);
    }
    public void Raycact()
    {

        RaycastHit2D hit2D = Physics2D.Raycast(_lastPosition, transform.right, 1000, layerMaskInRikoshet);

        if (hit2D)
        {
            normal = hit2D.normal;
        }
        
    }
    #endregion

    public void SetActiveFalse()
    {
        countJumpBull = 0;
        countRikoshetBull = 0;
        gameObject.SetActive(false);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground)||collision.gameObject.TryGetComponent<Wall>(out Wall wall))
        {
            if (rikoshetPuli == true)
            {
                ScetCountRikoshetBull();
            }
            else
            {
                SetActiveFalse();
            }
        }
       
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (jumpPuli == true||skvozniePuli==true)
            {
                if (addNewPuli == true && countJumpBull <=2)
                {
                    var pos = transform.position;
                    var rot = transform.rotation.eulerAngles.z;
                    newBulletEvent?.Invoke(pos, rot);
                }
                _lastEnemy = enemy.transform;
                ScetCounJumpBull();
            }
            else
            {
                SetActiveFalse();
            }
        }
       
    }

    



    #region  для прыгающих пули между противниками с использованием лучей
    //private void GetTargetRay()
    //{
    //    colls = new Collider2D[0];
    //    colls = Physics2D.OverlapCircleAll(transform.position, rangeFindEmeny, 1 << layerEmeny);
    //    collsRay.Clear();
    //    foreach (var coll in colls)
    //    {
    //        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, (coll.transform.position - transform.position).normalized, rangeFindEmeny, layer);

    //        if (hit2D)
    //        {
    //            if (hit2D.collider.TryGetComponent<Enemy>(out Enemy enemy))
    //            {
    //                collsRay.Add(coll);
    //            }
    //        }
    //    }

    //    if (collsRay.Count > 0)
    //    {
    //        NearTargetRay();
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }

    //}
    //private void NearTargetRay()
    //{
    //    if (collsRay.Count > 0)
    //    {
    //        Collider2D currentCollider = null;
    //        float dist = Mathf.Infinity;

    //        foreach (Collider2D coll in collsRay)
    //        {
    //            if (coll.gameObject == curTar)
    //            {
    //                continue;

    //            }
    //            float currentDist = Vector3.Distance(transform.position, coll.transform.position);


    //            if (currentDist < dist)
    //            {

    //                currentCollider = coll;
    //                dist = currentDist;
    //            }


    //        }
    //        if (currentCollider != null)
    //        {
    //            currentTarget = currentCollider.gameObject.transform.position;
    //            curTar = currentCollider.gameObject;
    //            SetRotate();

    //        }
    //        else
    //        {
    //            Destroy(gameObject);
    //        }
    //    }
    //}
    #endregion
}
