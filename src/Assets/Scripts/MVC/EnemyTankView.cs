﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour
{
    private EnemyTankController enemyTankController;

    Rigidbody rb;

    public Transform fireTransform;

    public Vector3 [] waypointsvector;

    public ParticleSystem tankExplosion;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        waypointsvector = enemyTankController.SetupWayPoints();
        enemyTankController.getTankModel().BulletShell.currentLaunchForce = enemyTankController.getTankModel().BulletShell.minlaunchForce;
        //fireButton = "Jump";
        //aimSlider.value = enemyTankController.getTankModel().BulletShell.minlaunchForce;
       
        enemyTankController.getTankModel().BulletShell.chargeSpeed = (enemyTankController.getTankModel().BulletShell.maxlaunchForce - enemyTankController.getTankModel().BulletShell.minlaunchForce) / enemyTankController.getTankModel().BulletShell.maxchargeTime;
        StartCoroutine(WaitForTime());
    }

    IEnumerator WaitForTime()
    {
        enemyTankController.Patrol();
        enemyTankController.ShootBullets();
        yield return new WaitForSeconds(3);        
        StartCoroutine(WaitForTime());
    }

    public void setTankController(EnemyTankController _enemyTankController)
    {
        enemyTankController = _enemyTankController;
    }

    public Rigidbody getRigidBody()
    {
        return rb;
    }

    public void setWaypoints(Vector3 [] _waypointsvector)
    {
        waypointsvector = _waypointsvector;
    }
    public float getHealth()
    {
        return enemyTankController.getTankModel().Health;
    }
    public void setHealth(float _damagevalue)
    {
        enemyTankController.getTankModel().Health -= _damagevalue;
    }

    public Rigidbody InstantiateBullet()
    {
        Rigidbody bulletInstance = Instantiate(enemyTankController.getTankModel().BulletShell._shellPrefab, fireTransform.position, fireTransform.rotation) as Rigidbody;
        return bulletInstance;
    }

    public void PlayExplosion()
    { 
        tankExplosion.transform.parent = null;
        tankExplosion.Play();
        Destroy(tankExplosion.gameObject, tankExplosion.main.duration);
    }
}
