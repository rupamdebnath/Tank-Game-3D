﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankController
{
    EnemyTankModel enemytankModel;
    EnemyTankView enemytankView;

    Rigidbody rb;
    
    NavMeshAgent agent;
    int waypointindex;
    Vector3 target;
    public EnemyTankController(EnemyTankModel _enemytankModel, EnemyTankView _enemytankView)
    {
        enemytankModel = _enemytankModel;
        enemytankView = GameObject.Instantiate(_enemytankView, enemytankModel.SpawnPosition.position, enemytankModel.SpawnPosition.rotation);
        rb = enemytankView.getRigidBody();
        
        enemytankView.setTankController(this);
        agent = enemytankView.GetComponent<NavMeshAgent>();
        waypointindex = 0;
        //waypoints = new Vector3[2];
    }

    public void Patrol()
    {        
        target = enemytankView.waypointsvector[waypointindex];
        if (Vector3.Distance(enemytankView.transform.position, target) > 1)
        {            
            UpdateDestination();
        }
        else
        {
            IterateWayPointIndex();
            UpdateDestination();
        }
    }

    public EnemyTankModel getTankModel()
    {
        return enemytankModel;
    }
    public EnemyTankView getTankView()
    {
        return enemytankView;
    }
    void UpdateDestination()
    {
        target = enemytankView.waypointsvector[waypointindex];
        agent.SetDestination(target); 
    }

    void IterateWayPointIndex()
    {
        waypointindex++;
        if (waypointindex == 2)
        {
            waypointindex = 0;
        }
    }

    public Vector3[] SetupWayPoints()
    {
        Vector3[] waypoints = new Vector3[2];
        waypoints[0] = enemytankModel.SpawnPosition.position + enemytankView.transform.forward * enemytankModel.patroldistance;
        waypoints[1] = enemytankModel.SpawnPosition.position - enemytankView.transform.forward * enemytankModel.patroldistance;
        return waypoints;

    }
}
