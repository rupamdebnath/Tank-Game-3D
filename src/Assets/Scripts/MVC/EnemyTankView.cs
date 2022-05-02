using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour
{
    private EnemyTankController enemyTankController;

    Rigidbody rb;

    public Vector3 [] waypointsvector;
    //int waypointindex;
    //Vector3 target;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        waypointsvector = enemyTankController.SetupWayPoints();
    }
    private void Update()
    {
        enemyTankController.Patrol();
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
}
