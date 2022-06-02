using System;
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

    private EnemyState currentState;
    [SerializeField]
    public EnemyIdle idlingState;
    [SerializeField]
    public EnemyPatrol patrollingState;
    [SerializeField]
    public EnemyChase chasingState;
    [SerializeField]
    public EnemyAttack attackingState;

    
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        currentState = idlingState;
        ChangeState(currentState);
        waypointsvector = enemyTankController.SetupWayPoints();
        enemyTankController.getTankModel().BulletShell.currentLaunchForce = enemyTankController.getTankModel().BulletShell.minlaunchForce;
       
        enemyTankController.getTankModel().BulletShell.chargeSpeed = (enemyTankController.getTankModel().BulletShell.maxlaunchForce - enemyTankController.getTankModel().BulletShell.minlaunchForce) / enemyTankController.getTankModel().BulletShell.maxchargeTime;

    }
    void Update()
    {
        ChangeState(currentState);

    }
    public void setTankController(EnemyTankController _enemyTankController)
    {
        enemyTankController = _enemyTankController;
    }
    public EnemyTankController getTankController()
    {
        return enemyTankController;
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

    public void ChangeState(EnemyState _newState)
    {
        if(currentState != null)
        {
            currentState.OnExitState();
        }
        currentState = _newState;
        currentState.OnEnterState();
    }  

}
