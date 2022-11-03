using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBullet : PlayerPoolsBullet
{
    public int poolCount;
    public bool autoExpant;
    public Pula prefabPula;
    public Transform container; 

    public PoolMono<Pula> pool;

    public TargetSystem targetSystem;
    public ManagerHPPlayer managerHPPlayer;

    public Transform posSpaun1;
    public Transform posSpaun21;
    public Transform posSpaun22;
    public Transform posSpaun31;
    public Transform posSpaun32;
    public Transform posSpaun33;

    public float timeShotDuble;
    
    


    private GameObject currentTarget;
    private float rotation;

    
    private void OnEnable()
    {
        Pula.newBulletEvent += Pula_newBullet;
    }
    private void OnDisable()
    {
        Pula.newBulletEvent -= Pula_newBullet;
    }




    public override void Initializade()
    {
        pool = new PoolMono<Pula>(prefabPula, poolCount, container);
        pool.autoExpand = autoExpant;
    }

    public override void ActivateBullet()
    {

        SetRotate();

        ShotMain();
        ShotBonus();

        if (managerHPPlayer.dubleShot)
        {
            Invoke("ShotDudle", timeShotDuble);
        }


    }
    public void ShotBonus()
    {
        switch (managerHPPlayer.dopCountBullet)
        {
            case 0:
                break;
            case 1:
                ShotAngle45();
                break;
            case 2:
                ShotAngle30();
                ShotAngle60();
                break;
            case 3:
                ShotAngle30();
                ShotAngle135();
                ShotAngle60();
                break;
            default:
                ShotAngle30();
                ShotAngle135();
                ShotAngle60();
                break;
        }
        if (managerHPPlayer.bullet90)
        {
            ShotAngle90();
        }
        if (managerHPPlayer.bullet180)
        {
            ShotAngle180();
        }
       
    }
    public void ShotMain()
    {
        switch (managerHPPlayer.countBullet)
        {
            case 1:
                var bull = pool.GetFreeElement(posSpaun1.position);
                bull.SetCurrentTarget(currentTarget);
                bull.SetMoveDirection(targetSystem.IsRight);
                bull.SetRotation(rotation);
                bull.SetBonus( managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
                break;
            case 2:
                var bull2 = pool.GetFreeElement(posSpaun21.position);
                bull2.SetCurrentTarget(currentTarget);
                bull2.SetMoveDirection(targetSystem.IsRight);
                bull2.SetRotation(rotation);
                bull2.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);


                var bull3 = pool.GetFreeElement(posSpaun22.position);
                bull3.SetCurrentTarget(currentTarget);
                bull3.SetMoveDirection(targetSystem.IsRight);
                bull3.SetRotation(rotation);
                bull3.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
                break;
            case 3:
                var bull4 = pool.GetFreeElement(posSpaun31.position);
                bull4.SetCurrentTarget(currentTarget);
                bull4.SetMoveDirection(targetSystem.IsRight);
                bull4.SetRotation(rotation);
                bull4.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);

                var bull5 = pool.GetFreeElement(posSpaun32.position);
                bull5.SetCurrentTarget(currentTarget);
                bull5.SetMoveDirection(targetSystem.IsRight);
                bull5.SetRotation(rotation);
                bull5.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);

                var bull6 = pool.GetFreeElement(posSpaun33.position);
                bull6.SetCurrentTarget(currentTarget);
                bull6.SetMoveDirection(targetSystem.IsRight);
                bull6.SetRotation(rotation);
                bull6.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
                break;
            default:
                var bull7 = pool.GetFreeElement(posSpaun1.position);
                bull7.SetCurrentTarget(currentTarget);
                bull7.SetMoveDirection(targetSystem.IsRight);
                bull7.SetRotation(rotation);
                bull7.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
                break;
        }
    }
    public void ShotDudle()
    {
        ShotMain();
        ShotBonus();
    }
    private void Pula_newBullet(Vector3 position, float rotationn)
    {
       
        var bull = pool.GetFreeElement(position);
       // bull.SetMoveDirection(targetSystem.IsRight);

        bull.SetRotation(rotationn - 15);
        bull.SetBonus(managerHPPlayer.skvozniePuli, false, managerHPPlayer.rikoshetPuli, false);
       

        var bull1 = pool.GetFreeElement(position);
        //bull1.SetMoveDirection(targetSystem.IsRight);

        bull1.SetRotation(rotationn + 15);
        bull1.SetBonus(managerHPPlayer.skvozniePuli, false, managerHPPlayer.rikoshetPuli, false);
      


    }
    public void ShotAngle15()
    {
        var bull = pool.GetFreeElement(posSpaun1.position);
        bull.SetMoveDirection(targetSystem.IsRight);
        bull.SetRotation(rotation - 15);
        bull.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
        bull.SetCurrentTarget(currentTarget);

        var bull2 = pool.GetFreeElement(posSpaun1.position);
        bull2.SetMoveDirection(targetSystem.IsRight);
        bull2.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
        bull2.SetRotation(rotation + 15);
        bull2.SetCurrentTarget(currentTarget);

    }
    public void ShotAngle30()
    {
        var bull = pool.GetFreeElement(posSpaun1.position);
        bull.SetMoveDirection(targetSystem.IsRight);
        bull.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
        bull.SetRotation(rotation - 30);
        bull.SetCurrentTarget(currentTarget);

        var bull2 = pool.GetFreeElement(posSpaun1.position);
        bull2.SetMoveDirection(targetSystem.IsRight);
        bull2.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
        bull2.SetRotation(rotation + 30);
        bull2.SetCurrentTarget(currentTarget);

    }
    public void ShotAngle45()
    {
        var bull = pool.GetFreeElement(posSpaun1.position);
        bull.SetMoveDirection(targetSystem.IsRight);
        bull.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
        bull.SetRotation(rotation - 45);
        bull.SetCurrentTarget(currentTarget);

        var bull2 = pool.GetFreeElement(posSpaun1.position);
        bull2.SetMoveDirection(targetSystem.IsRight);
        bull2.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
        bull2.SetRotation(rotation + 45);
        bull2.SetCurrentTarget(currentTarget);

    }
    public void ShotAngle60()
    {
        var bull = pool.GetFreeElement(posSpaun1.position);
        bull.SetMoveDirection(targetSystem.IsRight);
        bull.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
        bull.SetRotation(rotation - 60);
        bull.SetCurrentTarget(currentTarget);

        var bull2 = pool.GetFreeElement(posSpaun1.position);
        bull2.SetMoveDirection(targetSystem.IsRight);
        bull2.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
        bull2.SetRotation(rotation + 60);
        bull2.SetCurrentTarget(currentTarget);

    }
    public void ShotAngle135()
    {
        var bull = pool.GetFreeElement(posSpaun1.position);
        bull.SetMoveDirection(targetSystem.IsRight);
        bull.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
        bull.SetRotation(rotation - 75);
        bull.SetCurrentTarget(currentTarget);

        var bull2 = pool.GetFreeElement(posSpaun1.position);
        bull2.SetMoveDirection(targetSystem.IsRight);
        bull2.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
        bull2.SetRotation(rotation + 135);
        bull2.SetCurrentTarget(currentTarget);

    }
    public void ShotAngle90()
    {
        var bull = pool.GetFreeElement(posSpaun1.position);
        bull.SetMoveDirection(targetSystem.IsRight);
        bull.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
        bull.SetRotation(rotation - 90);
        bull.SetCurrentTarget(currentTarget);

        var bull2 = pool.GetFreeElement(posSpaun1.position);
        bull2.SetMoveDirection(targetSystem.IsRight);
        bull2.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
        bull2.SetRotation(rotation + 90);
        bull2.SetCurrentTarget(currentTarget);

    }

    public void ShotAngle180()
    {
        var bull = pool.GetFreeElement(posSpaun1.position);
        bull.SetMoveDirection(targetSystem.IsRight);
        bull.SetBonus(managerHPPlayer.skvozniePuli, managerHPPlayer.jumpPuli, managerHPPlayer.rikoshetPuli, managerHPPlayer.addNewPuli);
        bull.SetRotation(rotation - 180);
        bull.SetCurrentTarget(currentTarget);

    }


    private void SetRotate()
    {

        if (targetSystem.currentTarget != null)
        {
            currentTarget = targetSystem.currentTarget;
            Vector3 direction = new Vector2(currentTarget.transform.position.x - posSpaun1.position.x, currentTarget.transform.position.y - posSpaun1.position.y);
            rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.transform.eulerAngles = new Vector3(0, 0, rotation);
        }
        else
        {
            currentTarget = null;
            if (targetSystem.IsRight)
            {
                rotation = 0;
                this.posSpaun1.eulerAngles = new Vector3(0, 0, rotation);
            }
            else
            {
                rotation = 180;
                this.posSpaun1.eulerAngles = new Vector3(0, 0, rotation);
            }
        }
    }

    public void SetSpeedBullet(float kooficentDopSpeed)
    {
        foreach (var bulet in pool.GetPoolList())
        {
            bulet.speed *= kooficentDopSpeed;
        }
    }

}
