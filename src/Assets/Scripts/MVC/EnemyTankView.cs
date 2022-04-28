using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour
{
    private EnemyTankController enemyTankController;

    Rigidbody rb;

    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointindex;
    Vector3 target;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        waypoints[0] = GameObject.Find("WayPoint1").transform;
        waypoints[1] = GameObject.Find("WayPoint2").transform;

    }
    private void Update()
    {
        
        if (Vector3.Distance(transform.position, target) > 1)
        {
            Debug.Log(Vector3.Distance(transform.position, target));
            UpdateDestination();

        }
        else
        {
            IterateWayPointIndex();
            UpdateDestination();
        }
    }

    public void setTankController(EnemyTankController _enemyTankController)
    {
        enemyTankController = _enemyTankController;
    }

    public Rigidbody getRigidBody()
    {
        return rb;
    }

    void UpdateDestination()
    {
        Debug.Log("Destination");
        target = waypoints[waypointindex].position;
        agent.SetDestination(target);
    }

    void IterateWayPointIndex()
    {
        waypointindex++;
        if(waypointindex == waypoints.Length)
        {
            waypointindex = 0;
        }
    }
}
