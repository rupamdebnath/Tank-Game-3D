using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour
{
    private EnemyTankController enemyTankController;

    Rigidbody rb;

    public Transform[] waypoints;
    int waypointindex;
    Vector3 target;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        waypoints[0] = GameObject.Find("WayPoint1").transform;
        waypoints[1] = GameObject.Find("WayPoint2").transform;
    }

    private void Start()
    {


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

    public Transform[] getWayPoints()
    {
        return waypoints;
    }
}
